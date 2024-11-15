using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using SystemGestionAplication.backend.Controllers;
using SystemGestionAplication.backend.Database;
using SystemGestionAplication.frontend;
using UI_Support;

namespace SystemGestionAplication
{
    public partial class MainForm : Form
    {
        private const int BorderRadius = 25;
        private bool sesionActiva = false;


        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;
            this.FormBorderStyle = FormBorderStyle.None; // Quitar bordes para aplicar redondeo
            this.Shown += MainForm_Shown;
        }
        private void CargarEmpleadosConHuella()
        {
            var collection = MongoDBConnection.EmpleadosCollection;
            var filter = Builders<BsonDocument>.Filter.Exists("huella"); // Filtrar solo empleados con huella
            var empleadosConHuella = collection.Find(filter).ToList();

            // Limpiar ComboBox y agregar empleados con huella
            comboBoxEmpleadosConHuella.Items.Clear();
            foreach (var empleado in empleadosConHuella)
            {
                string nombreCompleto = $"{empleado["nombre"]} {empleado["apellido"]} - {empleado["cedula"]}";
                comboBoxEmpleadosConHuella.Items.Add(new ComboBoxItem { Text = nombreCompleto, Value = empleado["cedula"].AsString });
            }
        }
        private void MainForm_Load(object? sender, EventArgs? e)
        {
            // Configuración del Timer para actualizar hora y fecha
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            ApplyRoundedCorners(BorderRadius);
            CargarEmpleadosConHuella();
            CentrarControles();
        }
        private void ApplyRoundedCorners(int radius)
        {
            // Si la ventana está maximizada, eliminamos el borde redondeado
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.Region = null;
                return;
            }

            // Crear un rectángulo de la forma de la ventana
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            using (GraphicsPath path = new GraphicsPath())
            {
                // Añadir esquinas redondeadas
                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
                path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                // Aplicar la región al formulario
                this.Region = new Region(path);
            }
        }

        private void MainForm_Shown(object? sender, EventArgs? e)
        {
            ApplyRoundedCorners(BorderRadius);// Aquí estaba la llamada a ApplyRoundedRegion
        }

        private void timer1_Tick(object? sender, EventArgs? e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnOpenLogin_Click(object? sender, EventArgs? e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (LoginForm.CurrentUserRole != null) // verifica si se inició sesión
            {
                sesionActiva = true;
            }
        }

        private void btnAbrirAdmin_Click(object? sender, EventArgs? e)
        {
            // Verifica que el rol del usuario actual sea "admin"
            if (LoginForm.CurrentUserRole == "admin")
            {
                AdminForm adminForm = new AdminForm();
                adminForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Solo el usuario administrador puede acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAbrirRegistro_Click(object sender, EventArgs e)
        {
            // Verifica que el rol del usuario actual sea "admin" o "gerente"
            if (LoginForm.CurrentUserRole == "admin" || LoginForm.CurrentUserRole == "gerente")
            {
                RegistroForm registroForm = new RegistroForm();
                registroForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Solo el usuario administrador o gerente puede acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void MainForm_Resize(object? sender, EventArgs? e)
        {
            ApplyRoundedCorners(BorderRadius); // Aplicar redondeo al redimensionar
            AdjustControlPositions();
            CentrarControles();
        }
        private void CentrarControles()
        {
            int margenInferior = this.WindowState == FormWindowState.Maximized ? 400 : 200;

            // Centrar horizontalmente y colocar en la posición deseada respecto al inferior
            comboBoxEmpleadosConHuella.Left = (this.ClientSize.Width - comboBoxEmpleadosConHuella.Width) / 2;
            comboBoxEmpleadosConHuella.Top = this.ClientSize.Height - comboBoxEmpleadosConHuella.Height - btnRegistrarEntradaSalidaPorHuella.Height - margenInferior;

            btnRegistrarEntradaSalidaPorHuella.Left = (this.ClientSize.Width - btnRegistrarEntradaSalidaPorHuella.Width) / 2;
            btnRegistrarEntradaSalidaPorHuella.Top = comboBoxEmpleadosConHuella.Bottom + 10; // Espacio entre el ComboBox y el botón
        }
        private void AdjustControlPositions()
        {
            lblHora.Left = (this.ClientSize.Width - lblHora.Width) / 2;
            lblHora.Top = (this.ClientSize.Height / 4) - (lblHora.Height / 2);

            lblFecha.Left = (this.ClientSize.Width - lblFecha.Width) / 2;
            lblFecha.Top = lblHora.Bottom + 10;

            lblMensajeHuella.Left = (this.ClientSize.Width - lblMensajeHuella.Width) / 2;
            lblMensajeHuella.Top = lblFecha.Bottom + 10;

            lblInstruccion.Left = (this.ClientSize.Width - lblInstruccion.Width) / 2;
            lblInstruccion.Top = lblMensajeHuella.Bottom + 10;

            int totalButtonsWidth1 = btnAbrirRegistro.Width + btnAbrirAdmin.Width + 10;
            btnAbrirRegistro.Left = (this.ClientSize.Width - totalButtonsWidth1) / 2;
            btnAbrirRegistro.Top = lblInstruccion.Bottom + 20;

            btnAbrirAdmin.Left = btnAbrirRegistro.Right + 10;
            btnAbrirAdmin.Top = lblInstruccion.Bottom + 20;

            btnOpenLogin.Left = this.ClientSize.Width - btnOpenLogin.Width - 20;
            btnOpenLogin.Top = 20;

            btnCloseLogin.Left = btnOpenLogin.Left - btnCloseLogin.Width - 10;
            btnCloseLogin.Top = 20;

            int margenIzquierda = 20;
            int margenSuperior = 10;

            pictureBoxCerrar.Left = margenIzquierda;
            pictureBoxCerrar.Top = margenSuperior;

            pictureBoxMaximizar.Left = pictureBoxCerrar.Right + 5;
            pictureBoxMaximizar.Top = margenSuperior;

            pictureBoxMinimizar.Left = pictureBoxMaximizar.Right + 5;
            pictureBoxMinimizar.Top = margenSuperior;
        }

        private void btnCerrar_Click(object? sender, EventArgs? e)
        {
            this.Close();
        }

        private void btnMaximizar_Click(object? sender, EventArgs? e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimizar_Click(object? sender, EventArgs? e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void pictureBoxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCloseLogin_Click(object sender, EventArgs e)
        {
            if (sesionActiva)
            {
                sesionActiva = false;
                MessageBox.Show("La sesión ha sido cerrada exitosamente.", "Cerrar sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay una sesión activa para cerrar.", "Cerrar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRegistrarEntradaSalidaPorHuella_Click(object sender, EventArgs e)
        {
            if (comboBoxEmpleadosConHuella.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un empleado con huella registrada.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener la cédula del empleado seleccionado
            string cedulaEmpleado = ((ComboBoxItem)comboBoxEmpleadosConHuella.SelectedItem).Value;

            VerificationForm verificationForm = new VerificationForm(new AppData(), cedulaEmpleado);
            verificationForm.OnVerificationComplete += (mensaje) =>
            {
                if (!verificationForm.IsDisposed)
                {
                    MessageBox.Show(mensaje, "Registro de Entrada/Salida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            try
            {
                if (!verificationForm.IsDisposed)
                {
                    verificationForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El formulario no está disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ObjectDisposedException)
            {
                MessageBox.Show("No se puede mostrar el formulario, ya que ha sido cerrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

    }
}
