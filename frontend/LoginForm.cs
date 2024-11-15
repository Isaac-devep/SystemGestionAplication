using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemGestionAplication.backend.Controllers;

namespace SystemGestionAplication.frontend
{
    public partial class LoginForm : Form
    {

        private const int BorderRadius = 25;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;


        public LoginForm()
        {
            InitializeComponent();
            this.Resize += LoginForm_Resize;
            this.FormBorderStyle = FormBorderStyle.None;
            ApplyShadow();
            ApplyRoundedCorners(BorderRadius);
            this.MouseDown += (s, e) => LoginForm_MouseDown(s, e);
        }
        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
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
        private void LoginForm_Resize(object sender, EventArgs e)
        {
            ApplyRoundedCorners(BorderRadius);
        }

        private void ApplyShadow()
        {
            var margins = new Margins() { cxLeftWidth = 5, cxRightWidth = 0, cyTopHeight = 0, cyBottomHeight = 5 };
            DwmExtendFrameIntoClientArea(this.Handle, ref margins);
        }
        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_Enter(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "Username")
            {
                usernameTextBox.Text = "";
                usernameTextBox.ForeColor = Color.Black; // Cambia el color a negro para el texto normal
            }
        }

        private void usernameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                usernameTextBox.Text = "Username";
                usernameTextBox.ForeColor = Color.Gray; // Cambia el color a gris para simular el placeholder
            }
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "Password")
            {
                passwordTextBox.Text = "";
                passwordTextBox.ForeColor = Color.Gray; // Cambia el color a negro para el texto normal
                passwordTextBox.UseSystemPasswordChar = true; // Ocultar texto con asteriscos
            }
        }
        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                passwordTextBox.UseSystemPasswordChar = false; // Desactivar asteriscos para mostrar el placeholder
                passwordTextBox.Text = "Password";
                passwordTextBox.ForeColor = Color.Gray; // Cambia el color a gris para simular el placeholder
            }
        }

        // En LoginForm
        public static string? CurrentUserRole { get; set; } = null;
        public static string? CurrentUserCedula { get; set; } = null;

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            string token = AuthController.Login(username, password);

            if (token != null && token != "Usuario o contraseña incorrectos")
            {
                MessageBox.Show("Inicio de sesión exitoso!", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CurrentUserRole = AuthController.GetUserRole(token);
                CurrentUserCedula = username; // Asigna el nombre de usuario o la cédula aquí
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void passwordTogglePictureBox_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text != "Password") // Solo cambiar el carácter si el placeholder no está activo
            {
                // Alternar la visibilidad de la contraseña
                passwordTextBox.UseSystemPasswordChar = !passwordTextBox.UseSystemPasswordChar;

                // Cambiar la imagen del PictureBox según el estado
                if (passwordTextBox.UseSystemPasswordChar)
                {
                    // Contraseña oculta, mostrar icono de ojo cerrado
                    passwordTogglePictureBox.Image = Image.FromFile("C:\\Users\\isaac\\Desktop\\SystemGestionAplication\\SystemGestionAplication\\assets\\eye_closed.png");
                }
                else
                {
                    // Contraseña visible, mostrar icono de ojo abierto
                    passwordTogglePictureBox.Image = Image.FromFile("C:\\Users\\isaac\\Desktop\\SystemGestionAplication\\SystemGestionAplication\\assets\\eye_open.png");
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();

            mainForm.Show();
            this.Close();
        }
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);

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