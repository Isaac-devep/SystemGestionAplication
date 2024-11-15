namespace SystemGestionAplication
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnOpenLogin = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            btnCloseLogin = new Button();
            btnAbrirAdmin = new Button();
            btnAbrirRegistro = new Button();
            lblInstruccion = new Label();
            lblMensajeHuella = new Label();
            lblFecha = new Label();
            lblHora = new Label();
            pictureBoxMaximizar = new PictureBox();
            pictureBoxCerrar = new PictureBox();
            pictureBoxMinimizar = new PictureBox();
            btnRegistrarEntradaSalidaPorHuella = new Button();
            comboBoxEmpleadosConHuella = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinimizar).BeginInit();
            SuspendLayout();
            // 
            // btnOpenLogin
            // 
            btnOpenLogin.Cursor = Cursors.Hand;
            btnOpenLogin.FlatAppearance.BorderSize = 0;
            btnOpenLogin.FlatStyle = FlatStyle.Flat;
            btnOpenLogin.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpenLogin.Image = (Image)resources.GetObject("btnOpenLogin.Image");
            btnOpenLogin.Location = new Point(1019, 17);
            btnOpenLogin.Name = "btnOpenLogin";
            btnOpenLogin.Size = new Size(80, 54);
            btnOpenLogin.TabIndex = 8;
            btnOpenLogin.UseVisualStyleBackColor = true;
            btnOpenLogin.Click += btnOpenLogin_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // btnCloseLogin
            // 
            btnCloseLogin.Cursor = Cursors.Hand;
            btnCloseLogin.FlatAppearance.BorderSize = 0;
            btnCloseLogin.FlatStyle = FlatStyle.Flat;
            btnCloseLogin.Image = (Image)resources.GetObject("btnCloseLogin.Image");
            btnCloseLogin.Location = new Point(933, 17);
            btnCloseLogin.Name = "btnCloseLogin";
            btnCloseLogin.Size = new Size(80, 54);
            btnCloseLogin.TabIndex = 17;
            btnCloseLogin.UseVisualStyleBackColor = true;
            btnCloseLogin.Click += btnCloseLogin_Click;
            // 
            // btnAbrirAdmin
            // 
            btnAbrirAdmin.BackColor = Color.FromArgb(44, 62, 80);
            btnAbrirAdmin.Cursor = Cursors.Hand;
            btnAbrirAdmin.FlatAppearance.BorderSize = 0;
            btnAbrirAdmin.FlatStyle = FlatStyle.Flat;
            btnAbrirAdmin.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAbrirAdmin.ForeColor = Color.Ivory;
            btnAbrirAdmin.Location = new Point(596, 488);
            btnAbrirAdmin.Name = "btnAbrirAdmin";
            btnAbrirAdmin.Size = new Size(111, 35);
            btnAbrirAdmin.TabIndex = 9;
            btnAbrirAdmin.Text = "Administración";
            btnAbrirAdmin.UseVisualStyleBackColor = false;
            btnAbrirAdmin.Click += btnAbrirAdmin_Click;
            // 
            // btnAbrirRegistro
            // 
            btnAbrirRegistro.BackColor = Color.FromArgb(44, 62, 80);
            btnAbrirRegistro.Cursor = Cursors.Hand;
            btnAbrirRegistro.FlatAppearance.BorderSize = 0;
            btnAbrirRegistro.FlatStyle = FlatStyle.Flat;
            btnAbrirRegistro.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAbrirRegistro.ForeColor = Color.Ivory;
            btnAbrirRegistro.Location = new Point(401, 488);
            btnAbrirRegistro.Name = "btnAbrirRegistro";
            btnAbrirRegistro.Size = new Size(189, 35);
            btnAbrirRegistro.TabIndex = 11;
            btnAbrirRegistro.Text = "Registro de Entrada/Salida";
            btnAbrirRegistro.UseVisualStyleBackColor = false;
            btnAbrirRegistro.Click += btnAbrirRegistro_Click;
            // 
            // lblInstruccion
            // 
            lblInstruccion.AutoSize = true;
            lblInstruccion.Cursor = Cursors.IBeam;
            lblInstruccion.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblInstruccion.ForeColor = Color.Ivory;
            lblInstruccion.Location = new Point(421, 396);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(273, 27);
            lblInstruccion.TabIndex = 15;
            lblInstruccion.Text = "Coloca tu dedo en el lector";
            // 
            // lblMensajeHuella
            // 
            lblMensajeHuella.AutoSize = true;
            lblMensajeHuella.Cursor = Cursors.IBeam;
            lblMensajeHuella.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblMensajeHuella.ForeColor = Color.Ivory;
            lblMensajeHuella.Location = new Point(498, 366);
            lblMensajeHuella.Name = "lblMensajeHuella";
            lblMensajeHuella.Size = new Size(121, 17);
            lblMensajeHuella.TabIndex = 14;
            lblMensajeHuella.Text = "Coloca la Huella.....";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Cursor = Cursors.IBeam;
            lblFecha.Font = new Font("Tahoma", 40F, FontStyle.Bold, GraphicsUnit.Point);
            lblFecha.ForeColor = Color.Ivory;
            lblFecha.Location = new Point(376, 280);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(362, 65);
            lblFecha.TabIndex = 13;
            lblFecha.Text = "00/00/0000";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Cursor = Cursors.IBeam;
            lblHora.Font = new Font("Tahoma", 39.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblHora.ForeColor = Color.Ivory;
            lblHora.Location = new Point(423, 211);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(269, 64);
            lblHora.TabIndex = 12;
            lblHora.Text = "00:00:00";
            // 
            // pictureBoxMaximizar
            // 
            pictureBoxMaximizar.Cursor = Cursors.Hand;
            pictureBoxMaximizar.ErrorImage = Properties.Resources._4_removebg_preview;
            pictureBoxMaximizar.Image = (Image)resources.GetObject("pictureBoxMaximizar.Image");
            pictureBoxMaximizar.InitialImage = Properties.Resources._4_removebg_preview;
            pictureBoxMaximizar.Location = new Point(32, 8);
            pictureBoxMaximizar.Name = "pictureBoxMaximizar";
            pictureBoxMaximizar.Size = new Size(24, 21);
            pictureBoxMaximizar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMaximizar.TabIndex = 30;
            pictureBoxMaximizar.TabStop = false;
            pictureBoxMaximizar.Click += pictureBoxMaximizar_Click;
            // 
            // pictureBoxCerrar
            // 
            pictureBoxCerrar.Cursor = Cursors.Hand;
            pictureBoxCerrar.ErrorImage = Properties.Resources._4_removebg_preview;
            pictureBoxCerrar.Image = (Image)resources.GetObject("pictureBoxCerrar.Image");
            pictureBoxCerrar.InitialImage = Properties.Resources._4_removebg_preview;
            pictureBoxCerrar.Location = new Point(2, 8);
            pictureBoxCerrar.Name = "pictureBoxCerrar";
            pictureBoxCerrar.Size = new Size(24, 21);
            pictureBoxCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCerrar.TabIndex = 29;
            pictureBoxCerrar.TabStop = false;
            pictureBoxCerrar.Click += pictureBoxCerrar_Click;
            // 
            // pictureBoxMinimizar
            // 
            pictureBoxMinimizar.Cursor = Cursors.Hand;
            pictureBoxMinimizar.ErrorImage = Properties.Resources._4_removebg_preview;
            pictureBoxMinimizar.Image = (Image)resources.GetObject("pictureBoxMinimizar.Image");
            pictureBoxMinimizar.InitialImage = Properties.Resources._4_removebg_preview;
            pictureBoxMinimizar.Location = new Point(65, 8);
            pictureBoxMinimizar.Name = "pictureBoxMinimizar";
            pictureBoxMinimizar.Size = new Size(24, 21);
            pictureBoxMinimizar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMinimizar.TabIndex = 28;
            pictureBoxMinimizar.TabStop = false;
            pictureBoxMinimizar.Click += pictureBoxMinimizar_Click;
            // 
            // btnRegistrarEntradaSalidaPorHuella
            // 
            btnRegistrarEntradaSalidaPorHuella.FlatAppearance.BorderSize = 0;
            btnRegistrarEntradaSalidaPorHuella.FlatStyle = FlatStyle.Flat;
            btnRegistrarEntradaSalidaPorHuella.Location = new Point(505, 586);
            btnRegistrarEntradaSalidaPorHuella.Name = "btnRegistrarEntradaSalidaPorHuella";
            btnRegistrarEntradaSalidaPorHuella.Size = new Size(104, 29);
            btnRegistrarEntradaSalidaPorHuella.TabIndex = 31;
            btnRegistrarEntradaSalidaPorHuella.Text = "Entrada/Salida";
            btnRegistrarEntradaSalidaPorHuella.UseVisualStyleBackColor = true;
            btnRegistrarEntradaSalidaPorHuella.Click += btnRegistrarEntradaSalidaPorHuella_Click;
            // 
            // comboBoxEmpleadosConHuella
            // 
            comboBoxEmpleadosConHuella.FlatStyle = FlatStyle.Flat;
            comboBoxEmpleadosConHuella.FormattingEnabled = true;
            comboBoxEmpleadosConHuella.Location = new Point(497, 538);
            comboBoxEmpleadosConHuella.Name = "comboBoxEmpleadosConHuella";
            comboBoxEmpleadosConHuella.Size = new Size(121, 24);
            comboBoxEmpleadosConHuella.TabIndex = 32;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(1115, 735);
            Controls.Add(comboBoxEmpleadosConHuella);
            Controls.Add(btnRegistrarEntradaSalidaPorHuella);
            Controls.Add(pictureBoxMaximizar);
            Controls.Add(pictureBoxCerrar);
            Controls.Add(pictureBoxMinimizar);
            Controls.Add(lblFecha);
            Controls.Add(btnAbrirAdmin);
            Controls.Add(btnCloseLogin);
            Controls.Add(lblInstruccion);
            Controls.Add(btnOpenLogin);
            Controls.Add(btnAbrirRegistro);
            Controls.Add(lblHora);
            Controls.Add(lblMensajeHuella);
            Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Ivory;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestion de Personal";
            ((System.ComponentModel.ISupportInitialize)pictureBoxMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpenLogin;
        private System.Windows.Forms.Timer timer1;
        private Button btnCloseLogin;
        private Button btnAbrirAdmin;
        private Button btnAbrirRegistro;
        private Label lblInstruccion;
        private Label lblMensajeHuella;
        private Label lblFecha;
        private Label lblHora;
        private PictureBox pictureBoxMaximizar;
        private PictureBox pictureBoxCerrar;
        private PictureBox pictureBoxMinimizar;
        private Button btnRegistrarEntradaSalidaPorHuella;
        private ComboBox comboBoxEmpleadosConHuella;
    }
}
