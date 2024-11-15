namespace SystemGestionAplication.frontend
{
    partial class RegistroForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroForm));
            label1 = new Label();
            dataGridViewRegistros = new DataGridView();
            Cedula = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Hora = new DataGridViewTextBoxColumn();
            TipoEntrada = new DataGridViewTextBoxColumn();
            btnRegistrarSalida = new Button();
            btnRegistrarEntrada = new Button();
            comboBoxEmployees = new ComboBox();
            backButton = new Button();
            pictureBoxMinimizar = new PictureBox();
            pictureBoxCerrar = new PictureBox();
            pictureBoxMaximizar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRegistros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMaximizar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.IBeam;
            label1.Font = new Font("Tahoma", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(276, 27);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(383, 33);
            label1.TabIndex = 0;
            label1.Text = "Registro de Entrada/Salida";
            // 
            // dataGridViewRegistros
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewRegistros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewRegistros.BackgroundColor = Color.FromArgb(44, 62, 80);
            dataGridViewRegistros.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewRegistros.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewRegistros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRegistros.Columns.AddRange(new DataGridViewColumn[] { Cedula, Nombre, Apellido, Hora, TipoEntrada });
            dataGridViewRegistros.Cursor = Cursors.Hand;
            dataGridViewRegistros.GridColor = SystemColors.ActiveCaptionText;
            dataGridViewRegistros.Location = new Point(197, 180);
            dataGridViewRegistros.Margin = new Padding(4);
            dataGridViewRegistros.Name = "dataGridViewRegistros";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridViewRegistros.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewRegistros.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewRegistros.RowTemplate.Height = 25;
            dataGridViewRegistros.Size = new Size(561, 454);
            dataGridViewRegistros.TabIndex = 9;
            // 
            // Cedula
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Cedula.DefaultCellStyle = dataGridViewCellStyle2;
            Cedula.HeaderText = "Cédula";
            Cedula.Name = "Cedula";
            // 
            // Nombre
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Nombre.DefaultCellStyle = dataGridViewCellStyle3;
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // Apellido
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Apellido.DefaultCellStyle = dataGridViewCellStyle4;
            Apellido.HeaderText = "Apellido";
            Apellido.Name = "Apellido";
            // 
            // Hora
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Hora.DefaultCellStyle = dataGridViewCellStyle5;
            Hora.HeaderText = "Hora";
            Hora.Name = "Hora";
            // 
            // TipoEntrada
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TipoEntrada.DefaultCellStyle = dataGridViewCellStyle6;
            TipoEntrada.HeaderText = "Tipo de Entrada";
            TipoEntrada.Name = "TipoEntrada";
            TipoEntrada.Width = 120;
            // 
            // btnRegistrarSalida
            // 
            btnRegistrarSalida.Cursor = Cursors.Hand;
            btnRegistrarSalida.FlatAppearance.BorderSize = 0;
            btnRegistrarSalida.FlatStyle = FlatStyle.Flat;
            btnRegistrarSalida.Location = new Point(552, 124);
            btnRegistrarSalida.Margin = new Padding(4);
            btnRegistrarSalida.Name = "btnRegistrarSalida";
            btnRegistrarSalida.Size = new Size(114, 25);
            btnRegistrarSalida.TabIndex = 8;
            btnRegistrarSalida.Text = "Registrar Salida";
            btnRegistrarSalida.UseVisualStyleBackColor = true;
            btnRegistrarSalida.Click += btnRegistrarSalida_Click_1;
            // 
            // btnRegistrarEntrada
            // 
            btnRegistrarEntrada.Cursor = Cursors.Hand;
            btnRegistrarEntrada.FlatAppearance.BorderSize = 0;
            btnRegistrarEntrada.FlatStyle = FlatStyle.Flat;
            btnRegistrarEntrada.Location = new Point(419, 124);
            btnRegistrarEntrada.Margin = new Padding(4);
            btnRegistrarEntrada.Name = "btnRegistrarEntrada";
            btnRegistrarEntrada.Size = new Size(125, 25);
            btnRegistrarEntrada.TabIndex = 7;
            btnRegistrarEntrada.Text = "Registrar Entrada";
            btnRegistrarEntrada.UseVisualStyleBackColor = true;
            btnRegistrarEntrada.Click += btnRegistrarEntrada_Click_1;
            // 
            // comboBoxEmployees
            // 
            comboBoxEmployees.Location = new Point(197, 124);
            comboBoxEmployees.Margin = new Padding(4);
            comboBoxEmployees.Name = "comboBoxEmployees";
            comboBoxEmployees.Size = new Size(200, 24);
            comboBoxEmployees.TabIndex = 6;
            // 
            // backButton
            // 
            backButton.Cursor = Cursors.Hand;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Image = (Image)resources.GetObject("backButton.Image");
            backButton.Location = new Point(877, 695);
            backButton.Margin = new Padding(4);
            backButton.Name = "backButton";
            backButton.Size = new Size(35, 37);
            backButton.TabIndex = 10;
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // pictureBoxMinimizar
            // 
            pictureBoxMinimizar.Cursor = Cursors.Hand;
            pictureBoxMinimizar.ErrorImage = Properties.Resources._4_removebg_preview;
            pictureBoxMinimizar.Image = (Image)resources.GetObject("pictureBoxMinimizar.Image");
            pictureBoxMinimizar.InitialImage = Properties.Resources._4_removebg_preview;
            pictureBoxMinimizar.Location = new Point(72, 12);
            pictureBoxMinimizar.Name = "pictureBoxMinimizar";
            pictureBoxMinimizar.Size = new Size(24, 21);
            pictureBoxMinimizar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMinimizar.TabIndex = 25;
            pictureBoxMinimizar.TabStop = false;
            // 
            // pictureBoxCerrar
            // 
            pictureBoxCerrar.Cursor = Cursors.Hand;
            pictureBoxCerrar.ErrorImage = Properties.Resources._4_removebg_preview;
            pictureBoxCerrar.Image = (Image)resources.GetObject("pictureBoxCerrar.Image");
            pictureBoxCerrar.InitialImage = Properties.Resources._4_removebg_preview;
            pictureBoxCerrar.Location = new Point(12, 11);
            pictureBoxCerrar.Name = "pictureBoxCerrar";
            pictureBoxCerrar.Size = new Size(24, 21);
            pictureBoxCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCerrar.TabIndex = 26;
            pictureBoxCerrar.TabStop = false;
            pictureBoxCerrar.Click += pictureBoxCerrar_Click;
            // 
            // pictureBoxMaximizar
            // 
            pictureBoxMaximizar.Cursor = Cursors.Hand;
            pictureBoxMaximizar.ErrorImage = Properties.Resources._4_removebg_preview;
            pictureBoxMaximizar.Image = (Image)resources.GetObject("pictureBoxMaximizar.Image");
            pictureBoxMaximizar.InitialImage = Properties.Resources._4_removebg_preview;
            pictureBoxMaximizar.Location = new Point(42, 11);
            pictureBoxMaximizar.Name = "pictureBoxMaximizar";
            pictureBoxMaximizar.Size = new Size(24, 21);
            pictureBoxMaximizar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMaximizar.TabIndex = 27;
            pictureBoxMaximizar.TabStop = false;
            pictureBoxMaximizar.Click += pictureBoxMaximizar_Click_1;
            // 
            // RegistroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(936, 758);
            Controls.Add(pictureBoxMaximizar);
            Controls.Add(pictureBoxCerrar);
            Controls.Add(pictureBoxMinimizar);
            Controls.Add(backButton);
            Controls.Add(dataGridViewRegistros);
            Controls.Add(btnRegistrarSalida);
            Controls.Add(btnRegistrarEntrada);
            Controls.Add(comboBoxEmployees);
            Controls.Add(label1);
            Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Ivory;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "RegistroForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro";
            ((System.ComponentModel.ISupportInitialize)dataGridViewRegistros).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMaximizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridViewRegistros;
        private Button btnRegistrarSalida;
        private Button btnRegistrarEntrada;
        private ComboBox comboBoxEmployees;
        private Button backButton;
        private DataGridViewTextBoxColumn Cedula;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Hora;
        private DataGridViewTextBoxColumn TipoEntrada;
        private PictureBox pictureBoxMinimizar;
        private PictureBox pictureBoxCerrar;
        private PictureBox pictureBoxMaximizar;
    }
}