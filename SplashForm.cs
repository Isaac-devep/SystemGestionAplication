using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemGestionAplication
{
    public partial class SplashForm : Form
    {

        public SplashForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            progressBar1.Value += 1;
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
            }
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            timer1.Start();
            SetRoundedRegion(25);
        }

        // Método para redondear las esquinas del formulario
        private void SetRoundedRegion(int borderRadius)
        {
            // Define los límites del formulario y el radio del borde redondeado
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();
            int diameter = borderRadius * 2;

            // Añadir las esquinas redondeadas al GraphicsPath
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90); // Esquina superior izquierda
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90); // Esquina superior derecha
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90); // Esquina inferior derecha
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90); // Esquina inferior izquierda
            path.CloseFigure();

            // Asignar la región redondeada al formulario
            this.Region = new Region(path);
        }
    }
}
