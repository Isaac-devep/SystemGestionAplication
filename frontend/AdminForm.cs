using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemGestionAplication.backend.Controllers;
using SystemGestionAplication.backend.Database;
using UI_Support;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SystemGestionAplication.frontend
{
    public partial class AdminForm : Form
    {
        private const int BorderRadius = 25;
        private DPFP.Template currentTemplate = null;
        private AppData data = new AppData(); // Instancia de AppData

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public AdminForm()
        {
            InitializeComponent();
            this.Load += AdminForm_Load; // Suscribirse al evento Load

            this.Resize += AdminForm_Resize;
            this.FormBorderStyle = FormBorderStyle.None;
            ApplyShadow();
            ApplyRoundedCorners(BorderRadius);
            this.MouseDown += (s, e) => AdminForm_MouseDown(s, e);

            ConfigurarAutocompletado();
        }

        private void AdminForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private void ApplyRoundedCorners(int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
                path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                this.Region = new Region(path);
            }
        }
        private void ApplyShadow()
        {
            var margins = new Margins() { cxLeftWidth = 5, cxRightWidth = 0, cyTopHeight = 0, cyBottomHeight = 5 };
            DwmExtendFrameIntoClientArea(this.Handle, ref margins);
        }
        private void AdminForm_Resize(object sender, EventArgs e)
        {
            ApplyRoundedCorners(BorderRadius);
            AdjustControlLayout();
        }
        private void AdjustControlLayout()
        {
            const int topMargin = 10;
            const int leftMargin = 10;
            const int spacing = 5;
            const int titleTopPadding = 20;

            // Adjust positions of close/maximize/minimize icons
            pictureBoxCerrar.Location = new Point(leftMargin, topMargin);
            pictureBoxMinimizar.Location = new Point(pictureBoxCerrar.Right +spacing, topMargin);

            // Center the title label
            var lblTitle = Controls.OfType<Label>().FirstOrDefault(x => x.Text == "Administración");
            if (lblTitle != null)
            {
                lblTitle.AutoSize = true;
                lblTitle.Location = new Point(
                    (this.ClientSize.Width - lblTitle.Width) / 2,
                    titleTopPadding
                );
            }

            // Adjust size and position of employee data grid
            const int dataGridWidth = 771;
            const int dataGridHeight = 149;
            int gridBottomPadding = 100;
            dataGridViewEmpleados.Size = new Size(dataGridWidth, dataGridHeight);
            dataGridViewEmpleados.Location = new Point(
                (this.ClientSize.Width - dataGridWidth) / 2,
                this.ClientSize.Height - dataGridHeight - gridBottomPadding
            );
        }

        private void btnRegistrarEmpleado_Click(object sender, EventArgs e)
        {
            // Recoger los valores de los TextBox
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string cedula = txtCedula.Text;
            string cargo = txtCargo.Text;
            string fechaIngreso = dtpFechaIngreso.Value.ToString("yyyy-MM-dd");
            double salario;
            string turno = comboBoxTurno.SelectedItem != null ? comboBoxTurno.SelectedItem.ToString() : "día"; // Valor por defecto

            // Validar que el salario es un número decimal válido
            if (!double.TryParse(txtSalario.Text, out salario))
            {
                MessageBox.Show("Por favor, ingresa un salario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llamar al método de registro en el controlador
            string resultado = EmployeeController.RegisterEmployee(nombre, apellido, cedula, cargo, salario, fechaIngreso, turno);

            // Mostrar el resultado en un MessageBox
            MessageBox.Show(resultado, "Registro de Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos después del registro
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtCargo.Text = "";
            txtSalario.Text = "";
        }

        private void btnActualizarSalario_Click(object sender, EventArgs e)
        {
            string input = txtActualizarEmpleado.Text.Trim();
            string nuevoSalarioText = txtNuevoSalario.Text.Trim();
            double nuevoSalario;

            // Validar que el salario sea un número válido
            if (!double.TryParse(nuevoSalarioText, out nuevoSalario))
            {
                MessageBox.Show("Por favor, ingresa un salario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Dividir el input para verificar si contiene nombre y apellido
            string[] parts = input.Split(' ');
            string nombre = parts.Length > 1 ? parts[0] : "";
            string apellido = parts.Length > 1 ? parts[1] : "";
            string cedula = parts.Length == 1 ? input : ""; // Si solo hay una palabra, se asume que es la cédula

            // Llamar al método de actualización en el controlador
            string resultado = EmployeeController.UpdateEmployee(nombre, apellido, cedula, nuevoSalario);

            // Mostrar el resultado
            MessageBox.Show(resultado, "Actualización de Salario", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos después de actualizar
            txtActualizarEmpleado.Text = "";
            txtNuevoSalario.Text = "";
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            // Obtener el valor del TextBox
            string input = txtEliminarEmpleado.Text.Trim();

            // Variables para nombre, apellido y cédula
            string nombre = string.Empty;
            string apellido = string.Empty;
            string cedula = string.Empty;

            // Dividir el input en partes
            var partes = input.Split(' ');

            if (partes.Length == 1)
            {
                // Si solo hay un valor, asumimos que es la cédula
                cedula = partes[0];
            }
            else if (partes.Length == 2)
            {
                // Si hay dos valores, asumimos que son nombre y apellido
                nombre = partes[0];
                apellido = partes[1];
            }
            else
            {
                MessageBox.Show("Por favor, ingresa el nombre completo (nombre y apellido) o la cédula.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llamar al método de eliminación en el controlador
            string resultado = EmployeeController.DeleteEmployee(nombre, apellido, cedula);

            // Mostrar el resultado en un MessageBox
            MessageBox.Show(resultado, "Eliminación de Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar el campo después de eliminar
            txtEliminarEmpleado.Text = "";
        }

        private void btnGenerarInformeGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveDialog.FilterIndex = 1;
                    saveDialog.RestoreDirectory = true;
                    saveDialog.FileName = "ReporteHoras.xlsx";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        DateTime fechaInicio = DateTime.Now.AddDays(-30);
                        DateTime fechaFin = DateTime.Now;

                        string resultado = ReportGenerator.GenerateEmployeeHoursReport(
                            fechaInicio,
                            fechaFin,
                            saveDialog.FileName
                        );

                        MessageBox.Show(resultado, "Generación de Reporte",
                            MessageBoxButtons.OK,
                            resultado.Contains("Error") ? MessageBoxIcon.Error : MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarPermiso_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            string nombreCompleto = txtEmpleadoPermiso.Text.Trim(); // Campo que contiene nombre completo o cédula
            DateTime fechaInicio = dtpInicioFechaPermiso.Value.Date + dtpInicioHoraPermiso.Value.TimeOfDay;
            DateTime fechaFin = dtpFinFechaPermiso.Value.Date + dtpFinHoraPermiso.Value.TimeOfDay;
            string motivo = txtMotivoPermiso.Text.Trim(); // Campo del motivo
            bool justificado = chkPermisoPagado.Checked;

            // Separar el nombre completo en nombre y apellido si no es cédula
            string nombre = "";
            string apellido = "";
            string cedula = "";

            // Si es un número, lo tratamos como cédula; si no, como nombre completo
            if (long.TryParse(nombreCompleto, out _))
            {
                cedula = nombreCompleto;
            }
            else
            {
                var partes = nombreCompleto.Split(' ');
                if (partes.Length >= 2)
                {
                    nombre = partes[0];
                    apellido = partes[1];
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un nombre completo o una cédula válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Llamar al método para registrar el permiso en el controlador
            string resultado = EmployeeController.RegistrarPermiso(nombre, apellido, cedula, fechaInicio, fechaFin, motivo, justificado);

            // Mostrar el resultado al usuario
            MessageBox.Show(resultado, "Registro de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos después de registrar el permiso
            txtEmpleadoPermiso.Clear();
            txtMotivoPermiso.Clear();
            chkPermisoPagado.Checked = false;
        }

        private void btnListarEmpleado_Click(object sender, EventArgs e)
        {
            // Limpiar el DataGridView antes de cargar datos nuevos
            dataGridViewEmpleados.Rows.Clear();

            // Obtener la lista de empleados desde la base de datos
            var empleados = EmployeeController.GetEmployees();

            // Llenar el DataGridView con los datos obtenidos
            foreach (var empleado in empleados)
            {
                dataGridViewEmpleados.Rows.Add(
                    empleado["cedula"].ToString(),
                    empleado["nombre"].ToString(),
                    empleado["apellido"].ToString(),
                    empleado["cargo"].ToString(),
                    Convert.ToDouble(empleado["salario"]).ToString("C0", new CultureInfo("es-CO")), // formato de moneda
                    empleado["fecha_ingreso"].ToString()
                );
            }
        }

        private void dataGridViewEmpleados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener el ID (por ejemplo, la cédula) del empleado
            string cedula = dataGridViewEmpleados.Rows[e.RowIndex].Cells["CedulaColum"].Value.ToString();

            // Obtener el nombre de la columna editada y el nuevo valor de la celda
            string columnName = dataGridViewEmpleados.Columns[e.ColumnIndex].Name;
            var newValue = dataGridViewEmpleados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            // Llamar a un método para actualizar la base de datos
            UpdateEmployeeInDatabase(cedula, columnName, newValue);
        }

        private void UpdateEmployeeInDatabase(string cedula, string columnName, object newValue)
        {
            try
            {
                // Crear un filtro para buscar al empleado en la base de datos
                var filter = Builders<BsonDocument>.Filter.Eq("cedula", cedula);

                // Crear la actualización según la columna editada
                UpdateDefinition<BsonDocument> update = null;
                switch (columnName)
                {
                    case "NombreColum":
                        update = Builders<BsonDocument>.Update.Set("nombre", newValue.ToString());
                        break;
                    case "ApellidoColum":
                        update = Builders<BsonDocument>.Update.Set("apellido", newValue.ToString());
                        break;
                    case "CargoColum":
                        update = Builders<BsonDocument>.Update.Set("cargo", newValue.ToString());
                        break;
                    case "SalarioColum":
                        if (double.TryParse(newValue.ToString(), out double salario))
                        {
                            update = Builders<BsonDocument>.Update.Set("salario", salario);
                        }
                        else
                        {
                            MessageBox.Show("El salario debe ser un número válido.");
                            return;
                        }
                        break;
                    case "FechaIngresoColum":
                        if (DateTime.TryParse(newValue.ToString(), out DateTime fechaIngreso))
                        {
                            update = Builders<BsonDocument>.Update.Set("fecha_ingreso", fechaIngreso);
                        }
                        else
                        {
                            MessageBox.Show("La fecha de ingreso debe tener un formato válido.");
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show("Columna no válida para actualización.");
                        return;
                }

                if (update != null)
                {
                    // Actualizar el documento en la base de datos
                    var result = MongoDBConnection.EmpleadosCollection.UpdateOne(filter, update);

                    if (result.ModifiedCount > 0)
                    {
                        MessageBox.Show("Empleado actualizado correctamente en la base de datos.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el empleado o no hubo cambios para actualizar.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el empleado: {ex.Message}");
            }
        }

        private void GuardarHuellaEnBaseDeDatos(DPFP.Template template, string empleadoID)
        {
            try
            {
                // Validaciones adicionales
                if (template == null)
                    throw new ArgumentNullException(nameof(template), "El template de huella no puede ser nulo.");

                if (string.IsNullOrEmpty(empleadoID))
                    throw new ArgumentException("El ID del empleado no puede estar vacío.", nameof(empleadoID));

                // Convertir el template a bytes
                byte[] huellaBytes;
                using (var ms = new MemoryStream())
                {
                    template.Serialize(ms);
                    huellaBytes = ms.ToArray();
                }

                // Verificar que tengamos datos válidos
                if (huellaBytes == null || huellaBytes.Length == 0)
                    throw new InvalidOperationException("No se pudo convertir la huella a un formato válido.");

                // Intentar guardar en la base de datos
                bool resultado = EmployeeController.GuardarHuella(empleadoID, huellaBytes);

                if (resultado)
                {
                    MessageBox.Show("Huella dactilar registrada exitosamente.",
                                  "Éxito",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la huella en la base de datos. Por favor intente nuevamente.",
                                  "Error de Guardado",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la huella: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtCedula.Clear();
            currentTemplate = null;
            txtCedula.Focus();
        }

        // Método opcional para validar el formato de la cédula
        private bool ValidarFormatoCedula(string cedula)
        {
            // Validar que la cédula tenga exactamente 10 dígitos
            return !string.IsNullOrEmpty(cedula) && cedula.Length == 10 && cedula.All(char.IsDigit);
        }

        private void btnRegistrarHuella_Click(object sender, EventArgs e)
        {
            string cedula = txtEmpleadoID.Text.Trim();

            if (string.IsNullOrEmpty(cedula) || !ValidarFormatoCedula(cedula))
            {
                MessageBox.Show("Por favor ingrese un número de cédula válido.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtEmpleadoID.Focus();
                return;
            }

            // Verificar si ya existe un registro para esta cédula
            if (EmployeeController.VerificarEmpleadoExiste(cedula))
            {
                var respuesta = MessageBox.Show(
                    "Ya existe un registro para esta cédula. ¿Desea actualizarlo?",
                    "Registro Existente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }
            }

            try
            {
                AppData data = new AppData();
                data.InitializeNewSession(); // Usar el nuevo método de AppData para limpiar la sesión previa
                currentTemplate = null;

                using (EnrollmentForm enrollmentForm = new EnrollmentForm(data))
                {
                    enrollmentForm.EnrollmentControl.OnEnroll += (object Control, int Finger, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus eventStatus) =>
                    {
                        if (Template != null)
                        {
                            currentTemplate = Template;
                            data.UpdateRegistrationProgress(Finger, "Good");
                        }
                    };

                    if (enrollmentForm.ShowDialog() == DialogResult.OK && currentTemplate != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            currentTemplate.Serialize(ms);
                            byte[] huellaBytes = ms.ToArray();

                            if (huellaBytes != null && huellaBytes.Length > 0)
                            {
                                if (EmployeeController.GuardarHuella(cedula, huellaBytes))
                                {
                                    data.CompleteRegistration();
                                    MessageBox.Show("Huella registrada exitosamente.",
                                                    "Éxito",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                    LimpiarFormulario();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Los datos de la huella no son válidos.",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante el proceso de registro: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                currentTemplate = null;
            }
        }
        private void btnVerificarHuella_Click(object sender, EventArgs e)
        {
            string empleadoID = txtEmpleadoID.Text.Trim();

            if (string.IsNullOrEmpty(empleadoID))
            {
                MessageBox.Show("Por favor, ingrese un ID de empleado válido.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            // Crear una instancia de VerificationForm sin 'using'
            VerificationForm verificationForm = new VerificationForm(data, empleadoID);

            // Verificar si el formulario está en un estado válido antes de mostrarlo
            if (verificationForm != null && !verificationForm.IsDisposed)
            {
                verificationForm.ShowDialog(); // Mostrar el formulario
            }
            else
            {
                MessageBox.Show("No se puede acceder al formulario de verificación en este momento.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            comboBoxTurno.Items.Clear();
            comboBoxTurno.Items.AddRange(new string[] { "día", "noche", "mantenimiento" });
            comboBoxTurno.SelectedIndex = 0; // Seleccionar el primer elemento como predeterminado
        }

        private void btnGenerarInformeIndividual_Click(object sender, EventArgs e)
        {
            // Solicitar la cédula del empleado
            string cedula = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese la cédula del empleado para el informe:",
                "Cédula del Empleado",
                ""
            );

            if (string.IsNullOrEmpty(cedula))
            {
                MessageBox.Show("Debe ingresar una cédula válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Configurar el diálogo para guardar el archivo
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 1;
                saveDialog.RestoreDirectory = true;
                saveDialog.FileName = $"Reporte_Individual_{cedula}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Fechas de inicio y fin para el informe (por ejemplo, último mes)
                    DateTime fechaInicio = DateTime.Now.AddMonths(-1);
                    DateTime fechaFin = DateTime.Now;

                    // Llamar al método para generar el informe
                    string resultado = ReportGenerator.GenerateIndividualReport(
                        cedula,
                        fechaInicio,
                        fechaFin,
                        saveDialog.FileName
                    );

                    // Mostrar mensaje de éxito o error
                    MessageBox.Show(resultado, "Generación de Informe Individual",
                        MessageBoxButtons.OK,
                        resultado.Contains("Error") ? MessageBoxIcon.Error : MessageBoxIcon.Information);
                }
            }
        }

        private void btnGenerarInformePermisos_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un cuadro de diálogo para guardar el archivo Excel
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    // Configurar el filtro para que solo se muestren archivos de tipo Excel
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveDialog.FilterIndex = 1;
                    saveDialog.RestoreDirectory = true;
                    saveDialog.FileName = "PermisosJustificados.xlsx"; // Nombre de archivo sugerido

                    // Mostrar el cuadro de diálogo y verificar si el usuario hace clic en "Guardar"
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Definir el rango de fechas para el informe
                        DateTime fechaInicio = DateTime.Now.AddMonths(-1); // Cambia esto si necesitas otro rango
                        DateTime fechaFin = DateTime.Now;

                        // Llamar al método para generar el reporte y guardar el resultado en una variable
                        string resultado = ReportGenerator.GenerateJustifiedPermitsReport(fechaInicio, fechaFin, saveDialog.FileName);

                        // Mostrar el resultado al usuario
                        MessageBox.Show(resultado, "Generación de Informe de Permisos Justificados",
                            MessageBoxButtons.OK, resultado.Contains("Error") ? MessageBoxIcon.Error : MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores y mostrar un mensaje de error al usuario
                MessageBox.Show($"Error al generar el reporte de permisos justificados: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBoxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private List<string> listaCargos = new List<string> { "Sistemas", "Recursos Humanos", "Mantenimiento", "Ventas", "Planta" };

        private void ConfigurarAutocompletado()
        {
            // Autocompletado específico para txtMotivoPermiso
            ConfigurarAutocompletadoMotivoPermiso();

            // Autocompletado para campos específicos de nombre completo o cédula
            ConfigurarAutocompletadoParaNombreOCedula(txtActualizarEmpleado);
            ConfigurarAutocompletadoParaNombreOCedula(txtEliminarEmpleado);
            ConfigurarAutocompletadoParaNombreOCedula(txtEmpleadoPermiso);

            // Configuración de autocompletado general
            ConfigurarAutocompletadoTextBox(this.txtNombre, "nombre");
            ConfigurarAutocompletadoTextBox(this.txtApellido, "apellido");
            ConfigurarAutocompletadoTextBox(this.txtCedula, "cedula");
            ConfigurarAutocompletadoTextBox(this.txtEmpleadoID, "cedula");

            // Autocompletado específico para txtCargo con lista de opciones predefinidas
            this.txtCargo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtCargo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection cargoSource = new AutoCompleteStringCollection();
            cargoSource.AddRange(listaCargos.ToArray());
            this.txtCargo.AutoCompleteCustomSource = cargoSource;

            // Configuración para txtSalario
            ConfigurarAutocompletadoTextBox(this.txtSalario, "salario");
        }

        private void ConfigurarAutocompletadoTextBox(System.Windows.Forms.TextBox textBox, string campo)
        {
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();

            // Obtener datos únicos de la base de datos para el campo correspondiente
            var empleados = MongoDBConnection.EmpleadosCollection.Distinct<BsonValue>(campo, new BsonDocument()).ToList();

            foreach (var empleado in empleados)
            {
                if (empleado.IsString) // Solo agregar si el valor es de tipo String
                {
                    source.Add(empleado.AsString);
                }
            }

            textBox.AutoCompleteCustomSource = source;
        }
        private void ConfigurarAutocompletadoParaNombreOCedula(System.Windows.Forms.TextBox textBox)
        {
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();

            // Obtener datos de la base de datos y combinarlos en un solo campo para autocompletado
            var empleados = MongoDBConnection.EmpleadosCollection.Find(new BsonDocument()).ToList();

            foreach (var empleado in empleados)
            {
                string nombre = empleado.GetValue("nombre", "").AsString;
                string apellido = empleado.GetValue("apellido", "").AsString;
                string cedula = empleado.GetValue("cedula", "").AsString;

                // Agregar nombre completo y cédula al autocompletado
                source.Add($"{nombre} {apellido}");
                source.Add(cedula);
            }

            textBox.AutoCompleteCustomSource = source;
        }
        private void ConfigurarAutocompletadoMotivoPermiso()
        {
            txtMotivoPermiso.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMotivoPermiso.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection motivoSource = new AutoCompleteStringCollection();

            // Agregar los motivos a la colección
            motivoSource.AddRange(new string[]
            {
                "Enfermedad",
                "Cita",
                "Emergencia",
                "Luto",
                "Revisión",
                "Paternidad",
                "Maternidad",
                "Accidente",
                "Vacaciones",
                "Reposición"
            });

            txtMotivoPermiso.AutoCompleteCustomSource = motivoSource;
        }



        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);

        private void backButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();

            mainForm.Show();
            this.Close();
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Margins
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }
    }
}