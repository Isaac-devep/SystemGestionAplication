using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemGestionAplication.backend.Controllers;

namespace SystemGestionAplication.frontend
{
    public partial class RegistroForm : Form
    {
        private const int BorderRadius = 25;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public RegistroForm()
        {
            InitializeComponent();
            this.Load += RegistroForm_Load;
            this.Resize += RegistroForm_Resize;
            this.FormBorderStyle = FormBorderStyle.None;
            ApplyShadow();
            ConfigurarDataGridView();
            ApplyRoundedCorners(BorderRadius);
            this.MouseDown += (s, e) => RegistroForm_MouseDown(s!, e);
        }

        private void RegistroForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void RegistroForm_Load(object? sender, EventArgs e)
        {
            ApplyRoundedCorners(BorderRadius);
            ComboBoxEmployees_SelectedIndexChanged(null, null);

            if (pictureBoxCerrar != null && pictureBoxMaximizar != null && pictureBoxMinimizar != null)
            {
                int margin = 10;
                pictureBoxCerrar.Left = margin;
                pictureBoxMaximizar.Left = pictureBoxCerrar.Right + 5;
                pictureBoxMinimizar.Left = pictureBoxMaximizar.Right + 5;
            }

            AdjustControlLayout();
        }

        private void ConfigurarDataGridView()
        {
            if (dataGridViewRegistros != null)
            {
                dataGridViewRegistros.ColumnCount = 5;
                dataGridViewRegistros.Columns[0].Name = "Cedula";
                dataGridViewRegistros.Columns[1].Name = "Nombre";
                dataGridViewRegistros.Columns[2].Name = "Apellido";
                dataGridViewRegistros.Columns[3].Name = "Hora";
                dataGridViewRegistros.Columns[4].Name = "Tipo de Entrada";
            }
        }

        private void btnRegistrarEntrada_Click_1(object sender, EventArgs e)
        {
            RegistrarEvento("entrada");
        }

        private void btnRegistrarSalida_Click_1(object sender, EventArgs e)
        {
            RegistrarEvento("salida");
        }

        private void RegistrarEvento(string tipo)
        {
            if (comboBoxEmployees?.Text == null || comboBoxEmployees.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombreCompleto = comboBoxEmployees.Text;
            string[] partes = nombreCompleto.Split(' ');
            string nombre = partes.Length > 0 ? partes[0] : string.Empty;
            string apellido = partes.Length > 1 ? partes[1] : string.Empty;
            string cedula = comboBoxEmployees.SelectedValue.ToString() ?? string.Empty;

            // Validación adicional para asegurar que la cédula no sea vacía
            if (string.IsNullOrEmpty(cedula))
            {
                MessageBox.Show("La cédula del empleado no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var empleado = EmployeeController.GetEmployeeByNameOrCedula(nombre, apellido, cedula);

            if (empleado != null && dataGridViewRegistros != null)
            {
                // Obtenemos el valor de la cédula y verificamos que no sea null
                var cedulaValue = empleado["cedula"];
                if (cedulaValue == null)
                {
                    MessageBox.Show("Error: La cédula del empleado es inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

#pragma warning disable CS8604 // Posible argumento de referencia nulo
                string resultado = EmployeeController.RegistrarEntradaOSalida(tipo, cedulaValue.ToString());
#pragma warning restore CS8604 // Posible argumento de referencia nulo
                MessageBox.Show(resultado, "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // También verificamos los otros campos
                var nombreValue = empleado["nombre"];
                var apellidoValue = empleado["apellido"];

                if (nombreValue == null || apellidoValue == null)
                {
                    MessageBox.Show("Error: Datos del empleado incompletos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hora = DateTime.Now.ToString("HH:mm:ss");
                dataGridViewRegistros.Rows.Add(
                    cedulaValue.ToString(),
                    nombreValue.ToString(),
                    apellidoValue.ToString(),
                    hora,
                    tipo
                );
            }
            else
            {
                MessageBox.Show("Empleado no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxEmployees_SelectedIndexChanged(object? sender, EventArgs? e)
        {
            if (comboBoxEmployees == null) return;

            var employees = EmployeeController.GetEmployees();

            var employeeList = employees.Select(emp => new
            {
                NombreCompleto = $"{emp["nombre"]} {emp["apellido"]}",
                Cedula = emp["cedula"]
            }).ToList();

            comboBoxEmployees.DataSource = employeeList;
            comboBoxEmployees.DisplayMember = "NombreCompleto";
            comboBoxEmployees.ValueMember = "Cedula";
        }

        public void CargarRegistrosEnDataGridView()
        {
            if (dataGridViewRegistros == null) return;

            dataGridViewRegistros.Rows.Clear();
            var empleados = EmployeeController.GetEmployees();

            foreach (var empleado in empleados)
            {
                if (empleado.ContainsKey("registros_tiempos") &&
                    empleado["registros_tiempos"] is BsonArray registrosArray)
                {
                    var registros = registrosArray.Select(r => r.AsBsonDocument);

                    foreach (var registro in registros)
                    {
                        dataGridViewRegistros.Rows.Add(
                            empleado["cedula"].ToString(),
                            empleado["nombre"].ToString(),
                            empleado["apellido"].ToString(),
                            registro["timestamp"].ToString(),
                            registro["tipo"].ToString()
                        );
                    }
                }
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

        private void RegistroForm_Resize(object? sender, EventArgs e)
        {
            ApplyRoundedCorners(BorderRadius);
            AdjustControlLayout();
        }

        private void AdjustControlLayout()
        {
            const int topMargin = 10;
            const int leftMargin = 10;
            const int spacing = 5;
            const int titleTopPadding = 80;

            if (pictureBoxCerrar != null && pictureBoxMaximizar != null && pictureBoxMinimizar != null)
            {
                pictureBoxCerrar.Location = new Point(leftMargin, topMargin);
                pictureBoxMaximizar.Location = new Point(pictureBoxCerrar.Right + spacing, topMargin);
                pictureBoxMinimizar.Location = new Point(pictureBoxMaximizar.Right + spacing, topMargin);
            }

            var lblTitle = Controls.OfType<Label>().FirstOrDefault(x => x?.Text == "Registro de Entrada/Salida");
            if (lblTitle != null)
            {
                lblTitle.AutoSize = true;
                lblTitle.Location = new Point(
                    (this.ClientSize.Width - lblTitle.Width) / 2,
                    titleTopPadding
                );

                if (comboBoxEmployees != null && dataGridViewRegistros != null &&
                    btnRegistrarEntrada != null && btnRegistrarSalida != null)
                {
                    int totalControlsHeight = comboBoxEmployees.Height + spacing + dataGridViewRegistros.Height;
                    int startY = Math.Max((this.ClientSize.Height - totalControlsHeight) / 2,
                                        lblTitle.Bottom + spacing * 2);

                    int groupWidth = comboBoxEmployees.Width + spacing +
                                   btnRegistrarEntrada.Width + spacing +
                                   btnRegistrarSalida.Width;

                    int startX = (this.ClientSize.Width - groupWidth) / 2;

                    comboBoxEmployees.Location = new Point(startX, startY);
                    btnRegistrarEntrada.Location = new Point(
                        comboBoxEmployees.Right + spacing,
                        startY
                    );
                    btnRegistrarSalida.Location = new Point(
                        btnRegistrarEntrada.Right + spacing,
                        startY
                    );

                    const int dataGridWidth = 561;
                    const int dataGridHeight = 454;
                    const int gridTopPadding = 20;

                    dataGridViewRegistros.Size = new Size(dataGridWidth, dataGridHeight);
                    dataGridViewRegistros.Location = new Point(
                        (this.ClientSize.Width - dataGridWidth) / 2,
                        startY + comboBoxEmployees.Height + gridTopPadding
                    );
                }
            }

            if (backButton != null)
            {
                backButton.Location = new Point(
                    this.ClientSize.Width - backButton.Width - leftMargin,
                    this.ClientSize.Height - backButton.Height - spacing * 2
                );
            }

            var loginButton = this.Controls.OfType<Button>().FirstOrDefault(x => x?.Text?.ToUpper() == "LOGIN");
            if (loginButton != null)
            {
                loginButton.Location = new Point(
                    this.ClientSize.Width - loginButton.Width - leftMargin,
                    topMargin
                );
            }
        }

        private void ApplyShadow()
        {
            var margins = new Margins() { cxLeftWidth = 5, cxRightWidth = 0, cyTopHeight = 0, cyBottomHeight = 5 };
            DwmExtendFrameIntoClientArea(this.Handle, ref margins);
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);

        private void backButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private void pictureBoxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxMaximizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Normal ?
                              FormWindowState.Maximized :
                              FormWindowState.Normal;
        }

        private void pictureBoxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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