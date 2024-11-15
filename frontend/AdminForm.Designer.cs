namespace SystemGestionAplication.frontend
{
    partial class AdminForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            lblRegistrarEmpleado = new Label();
            label1 = new Label();
            lbl1 = new Label();
            lbl3 = new Label();
            lbl5 = new Label();
            lbl6 = new Label();
            lbl2 = new Label();
            dtpFechaIngreso = new DateTimePicker();
            lbl4 = new Label();
            txtNombre = new TextBox();
            txtCedula = new TextBox();
            txtCargo = new TextBox();
            txtSalario = new TextBox();
            txtApellido = new TextBox();
            btnRegistrarEmpleado = new Button();
            lbl7 = new Label();
            lblEliminarEmpleado = new Label();
            txtEliminarEmpleado = new TextBox();
            btnEliminarEmpleado = new Button();
            lbl8 = new Label();
            lblActualizarSalario = new Label();
            txtActualizarEmpleado = new TextBox();
            lbl9 = new Label();
            txtNuevoSalario = new TextBox();
            btnActualizarSalario = new Button();
            lbl10 = new Label();
            btnGenerarInformeGeneral = new Button();
            btnListarEmpleado = new Button();
            lbl11 = new Label();
            lblRegistrarPermiso = new Label();
            txtEmpleadoPermiso = new TextBox();
            lbl12 = new Label();
            lbl13 = new Label();
            lbl14 = new Label();
            dtpInicioFechaPermiso = new DateTimePicker();
            dtpFinFechaPermiso = new DateTimePicker();
            lbl15 = new Label();
            lbl16 = new Label();
            dtpInicioHoraPermiso = new DateTimePicker();
            dtpFinHoraPermiso = new DateTimePicker();
            txtMotivoPermiso = new TextBox();
            chkPermisoPagado = new CheckBox();
            btnRegistrarPermiso = new Button();
            CedulaColumn = new DataGridViewTextBoxColumn();
            NombreColumn = new DataGridViewTextBoxColumn();
            ApellidoColumn = new DataGridViewTextBoxColumn();
            CargoColumn = new DataGridViewTextBoxColumn();
            SalarioColumn = new DataGridViewTextBoxColumn();
            FechaIngresoColumn = new DataGridViewTextBoxColumn();
            dataGridViewEmpleados = new DataGridView();
            CedulaColum = new DataGridViewTextBoxColumn();
            NombreColum = new DataGridViewTextBoxColumn();
            ApellidoColum = new DataGridViewTextBoxColumn();
            CargoColum = new DataGridViewTextBoxColumn();
            SalarioColum = new DataGridViewTextBoxColumn();
            FechaIngresoColum = new DataGridViewTextBoxColumn();
            btnGenerarInformePermisos = new Button();
            backButton = new Button();
            btnRegistrarHuella = new Button();
            txtEmpleadoID = new TextBox();
            LBL = new Label();
            label2 = new Label();
            btnVerificarHuella = new Button();
            comboBoxTurno = new ComboBox();
            label3 = new Label();
            btnGenerarInformeIndividual = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pictureBoxCerrar = new PictureBox();
            pictureBoxMinimizar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpleados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinimizar).BeginInit();
            SuspendLayout();
            // 
            // lblRegistrarEmpleado
            // 
            lblRegistrarEmpleado.AutoSize = true;
            lblRegistrarEmpleado.Cursor = Cursors.IBeam;
            lblRegistrarEmpleado.Font = new Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblRegistrarEmpleado.ForeColor = Color.Ivory;
            lblRegistrarEmpleado.Location = new Point(178, 116);
            lblRegistrarEmpleado.Margin = new Padding(4, 0, 4, 0);
            lblRegistrarEmpleado.Name = "lblRegistrarEmpleado";
            lblRegistrarEmpleado.Size = new Size(218, 25);
            lblRegistrarEmpleado.TabIndex = 0;
            lblRegistrarEmpleado.Text = "Registrar Empleado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.IBeam;
            label1.Font = new Font("Tahoma", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Ivory;
            label1.Location = new Point(531, 27);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(218, 33);
            label1.TabIndex = 1;
            label1.Text = "Administración";
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Cursor = Cursors.IBeam;
            lbl1.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl1.ForeColor = Color.Ivory;
            lbl1.Location = new Point(50, 166);
            lbl1.Margin = new Padding(4, 0, 4, 0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(52, 16);
            lbl1.TabIndex = 2;
            lbl1.Text = "Nombre";
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Cursor = Cursors.IBeam;
            lbl3.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl3.ForeColor = Color.Ivory;
            lbl3.Location = new Point(50, 210);
            lbl3.Margin = new Padding(4, 0, 4, 0);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(46, 16);
            lbl3.TabIndex = 3;
            lbl3.Text = "Cédula";
            // 
            // lbl5
            // 
            lbl5.AutoSize = true;
            lbl5.Cursor = Cursors.IBeam;
            lbl5.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl5.ForeColor = Color.Ivory;
            lbl5.Location = new Point(50, 254);
            lbl5.Margin = new Padding(4, 0, 4, 0);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(41, 16);
            lbl5.TabIndex = 4;
            lbl5.Text = "Cargo";
            // 
            // lbl6
            // 
            lbl6.AutoSize = true;
            lbl6.Cursor = Cursors.IBeam;
            lbl6.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl6.ForeColor = Color.Ivory;
            lbl6.Location = new Point(240, 254);
            lbl6.Margin = new Padding(4, 0, 4, 0);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(47, 16);
            lbl6.TabIndex = 5;
            lbl6.Text = "Salario";
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Cursor = Cursors.IBeam;
            lbl2.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl2.ForeColor = Color.Ivory;
            lbl2.Location = new Point(240, 166);
            lbl2.Margin = new Padding(4, 0, 4, 0);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(52, 16);
            lbl2.TabIndex = 6;
            lbl2.Text = "Apellido";
            // 
            // dtpFechaIngreso
            // 
            dtpFechaIngreso.CalendarMonthBackground = Color.FromArgb(44, 62, 80);
            dtpFechaIngreso.Cursor = Cursors.Hand;
            dtpFechaIngreso.Location = new Point(352, 204);
            dtpFechaIngreso.Margin = new Padding(4);
            dtpFechaIngreso.Name = "dtpFechaIngreso";
            dtpFechaIngreso.Size = new Size(128, 24);
            dtpFechaIngreso.TabIndex = 7;
            // 
            // lbl4
            // 
            lbl4.AutoSize = true;
            lbl4.Cursor = Cursors.IBeam;
            lbl4.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl4.ForeColor = Color.Ivory;
            lbl4.Location = new Point(240, 210);
            lbl4.Margin = new Padding(4, 0, 4, 0);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(106, 16);
            lbl4.TabIndex = 8;
            lbl4.Text = "Fecha de Ingreso";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(44, 62, 80);
            txtNombre.Cursor = Cursors.IBeam;
            txtNombre.ForeColor = Color.DarkGray;
            txtNombre.Location = new Point(106, 164);
            txtNombre.Margin = new Padding(4);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "  Nombre";
            txtNombre.Size = new Size(128, 24);
            txtNombre.TabIndex = 9;
            // 
            // txtCedula
            // 
            txtCedula.BackColor = Color.FromArgb(44, 62, 80);
            txtCedula.Cursor = Cursors.IBeam;
            txtCedula.ForeColor = Color.DarkGray;
            txtCedula.Location = new Point(106, 210);
            txtCedula.Margin = new Padding(4);
            txtCedula.Name = "txtCedula";
            txtCedula.PlaceholderText = "  Cédula";
            txtCedula.Size = new Size(128, 24);
            txtCedula.TabIndex = 10;
            // 
            // txtCargo
            // 
            txtCargo.BackColor = Color.FromArgb(44, 62, 80);
            txtCargo.Cursor = Cursors.IBeam;
            txtCargo.ForeColor = Color.DarkGray;
            txtCargo.Location = new Point(106, 254);
            txtCargo.Margin = new Padding(4);
            txtCargo.Name = "txtCargo";
            txtCargo.PlaceholderText = "  Cargo";
            txtCargo.Size = new Size(128, 24);
            txtCargo.TabIndex = 11;
            // 
            // txtSalario
            // 
            txtSalario.BackColor = Color.FromArgb(44, 62, 80);
            txtSalario.Cursor = Cursors.IBeam;
            txtSalario.ForeColor = Color.DarkGray;
            txtSalario.Location = new Point(352, 254);
            txtSalario.Margin = new Padding(4);
            txtSalario.Name = "txtSalario";
            txtSalario.PlaceholderText = "  Salario";
            txtSalario.Size = new Size(128, 24);
            txtSalario.TabIndex = 13;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.FromArgb(44, 62, 80);
            txtApellido.Cursor = Cursors.IBeam;
            txtApellido.ForeColor = Color.DarkGray;
            txtApellido.Location = new Point(352, 164);
            txtApellido.Margin = new Padding(4);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "  Apellido";
            txtApellido.Size = new Size(128, 24);
            txtApellido.TabIndex = 12;
            // 
            // btnRegistrarEmpleado
            // 
            btnRegistrarEmpleado.Cursor = Cursors.Hand;
            btnRegistrarEmpleado.FlatAppearance.BorderSize = 0;
            btnRegistrarEmpleado.FlatStyle = FlatStyle.Flat;
            btnRegistrarEmpleado.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegistrarEmpleado.ForeColor = Color.Ivory;
            btnRegistrarEmpleado.Location = new Point(204, 345);
            btnRegistrarEmpleado.Margin = new Padding(4);
            btnRegistrarEmpleado.Name = "btnRegistrarEmpleado";
            btnRegistrarEmpleado.Size = new Size(142, 31);
            btnRegistrarEmpleado.TabIndex = 14;
            btnRegistrarEmpleado.Text = "Registrar Empleado";
            btnRegistrarEmpleado.UseVisualStyleBackColor = true;
            btnRegistrarEmpleado.Click += btnRegistrarEmpleado_Click;
            // 
            // lbl7
            // 
            lbl7.AutoSize = true;
            lbl7.Cursor = Cursors.IBeam;
            lbl7.Font = new Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl7.ForeColor = Color.Ivory;
            lbl7.Location = new Point(590, 324);
            lbl7.Margin = new Padding(4, 0, 4, 0);
            lbl7.Name = "lbl7";
            lbl7.Size = new Size(207, 25);
            lbl7.TabIndex = 15;
            lbl7.Text = "Eliminar Empleado";
            // 
            // lblEliminarEmpleado
            // 
            lblEliminarEmpleado.AutoSize = true;
            lblEliminarEmpleado.Cursor = Cursors.IBeam;
            lblEliminarEmpleado.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblEliminarEmpleado.ForeColor = Color.Ivory;
            lblEliminarEmpleado.Location = new Point(514, 372);
            lblEliminarEmpleado.Margin = new Padding(4, 0, 4, 0);
            lblEliminarEmpleado.Name = "lblEliminarEmpleado";
            lblEliminarEmpleado.Size = new Size(177, 16);
            lblEliminarEmpleado.TabIndex = 16;
            lblEliminarEmpleado.Text = "Nombre del Empleado/Cédula";
            // 
            // txtEliminarEmpleado
            // 
            txtEliminarEmpleado.BackColor = Color.FromArgb(44, 62, 80);
            txtEliminarEmpleado.Cursor = Cursors.IBeam;
            txtEliminarEmpleado.ForeColor = Color.DarkGray;
            txtEliminarEmpleado.Location = new Point(712, 372);
            txtEliminarEmpleado.Margin = new Padding(4);
            txtEliminarEmpleado.Name = "txtEliminarEmpleado";
            txtEliminarEmpleado.PlaceholderText = "  Cedula/NombreCompleto";
            txtEliminarEmpleado.Size = new Size(154, 24);
            txtEliminarEmpleado.TabIndex = 17;
            // 
            // btnEliminarEmpleado
            // 
            btnEliminarEmpleado.Cursor = Cursors.Hand;
            btnEliminarEmpleado.FlatAppearance.BorderSize = 0;
            btnEliminarEmpleado.FlatStyle = FlatStyle.Flat;
            btnEliminarEmpleado.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminarEmpleado.ForeColor = Color.Ivory;
            btnEliminarEmpleado.Location = new Point(615, 416);
            btnEliminarEmpleado.Margin = new Padding(4);
            btnEliminarEmpleado.Name = "btnEliminarEmpleado";
            btnEliminarEmpleado.Size = new Size(142, 31);
            btnEliminarEmpleado.TabIndex = 18;
            btnEliminarEmpleado.Text = "Eliminar Empleado";
            btnEliminarEmpleado.UseVisualStyleBackColor = true;
            btnEliminarEmpleado.Click += btnEliminarEmpleado_Click;
            // 
            // lbl8
            // 
            lbl8.AutoSize = true;
            lbl8.Cursor = Cursors.IBeam;
            lbl8.Font = new Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl8.ForeColor = Color.Ivory;
            lbl8.Location = new Point(590, 116);
            lbl8.Margin = new Padding(4, 0, 4, 0);
            lbl8.Name = "lbl8";
            lbl8.Size = new Size(196, 25);
            lbl8.TabIndex = 19;
            lbl8.Text = "Actualizar Salario";
            // 
            // lblActualizarSalario
            // 
            lblActualizarSalario.AutoSize = true;
            lblActualizarSalario.Cursor = Cursors.IBeam;
            lblActualizarSalario.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblActualizarSalario.ForeColor = Color.Ivory;
            lblActualizarSalario.Location = new Point(526, 166);
            lblActualizarSalario.Margin = new Padding(4, 0, 4, 0);
            lblActualizarSalario.Name = "lblActualizarSalario";
            lblActualizarSalario.Size = new Size(177, 16);
            lblActualizarSalario.TabIndex = 20;
            lblActualizarSalario.Text = "Nombre del Empleado/Cédula";
            // 
            // txtActualizarEmpleado
            // 
            txtActualizarEmpleado.BackColor = Color.FromArgb(44, 62, 80);
            txtActualizarEmpleado.Cursor = Cursors.IBeam;
            txtActualizarEmpleado.ForeColor = Color.DarkGray;
            txtActualizarEmpleado.Location = new Point(729, 164);
            txtActualizarEmpleado.Margin = new Padding(4);
            txtActualizarEmpleado.Name = "txtActualizarEmpleado";
            txtActualizarEmpleado.PlaceholderText = "  Cedula/NombreCompleto";
            txtActualizarEmpleado.Size = new Size(154, 24);
            txtActualizarEmpleado.TabIndex = 21;
            // 
            // lbl9
            // 
            lbl9.AutoSize = true;
            lbl9.Cursor = Cursors.IBeam;
            lbl9.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl9.ForeColor = Color.Ivory;
            lbl9.Location = new Point(565, 212);
            lbl9.Margin = new Padding(4, 0, 4, 0);
            lbl9.Name = "lbl9";
            lbl9.Size = new Size(86, 16);
            lbl9.TabIndex = 22;
            lbl9.Text = "Nuevo Salario";
            // 
            // txtNuevoSalario
            // 
            txtNuevoSalario.BackColor = Color.FromArgb(44, 62, 80);
            txtNuevoSalario.Cursor = Cursors.IBeam;
            txtNuevoSalario.ForeColor = Color.DarkGray;
            txtNuevoSalario.Location = new Point(729, 210);
            txtNuevoSalario.Margin = new Padding(4);
            txtNuevoSalario.Name = "txtNuevoSalario";
            txtNuevoSalario.PlaceholderText = "  Salario";
            txtNuevoSalario.Size = new Size(128, 24);
            txtNuevoSalario.TabIndex = 23;
            // 
            // btnActualizarSalario
            // 
            btnActualizarSalario.Cursor = Cursors.Hand;
            btnActualizarSalario.FlatAppearance.BorderSize = 0;
            btnActualizarSalario.FlatStyle = FlatStyle.Flat;
            btnActualizarSalario.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnActualizarSalario.ForeColor = Color.Ivory;
            btnActualizarSalario.Location = new Point(609, 254);
            btnActualizarSalario.Margin = new Padding(4);
            btnActualizarSalario.Name = "btnActualizarSalario";
            btnActualizarSalario.Size = new Size(142, 31);
            btnActualizarSalario.TabIndex = 24;
            btnActualizarSalario.Text = "Actualizar Empleado";
            btnActualizarSalario.UseVisualStyleBackColor = true;
            btnActualizarSalario.Click += btnActualizarSalario_Click;
            // 
            // lbl10
            // 
            lbl10.AutoSize = true;
            lbl10.Cursor = Cursors.IBeam;
            lbl10.Font = new Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl10.ForeColor = Color.Ivory;
            lbl10.Location = new Point(1074, 379);
            lbl10.Margin = new Padding(4, 0, 4, 0);
            lbl10.Name = "lbl10";
            lbl10.Size = new Size(187, 25);
            lbl10.TabIndex = 25;
            lbl10.Text = "Generar Informe";
            // 
            // btnGenerarInformeGeneral
            // 
            btnGenerarInformeGeneral.Cursor = Cursors.Hand;
            btnGenerarInformeGeneral.FlatAppearance.BorderSize = 0;
            btnGenerarInformeGeneral.FlatStyle = FlatStyle.Flat;
            btnGenerarInformeGeneral.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnGenerarInformeGeneral.ForeColor = Color.Ivory;
            btnGenerarInformeGeneral.Location = new Point(1014, 425);
            btnGenerarInformeGeneral.Margin = new Padding(4);
            btnGenerarInformeGeneral.Name = "btnGenerarInformeGeneral";
            btnGenerarInformeGeneral.Size = new Size(166, 31);
            btnGenerarInformeGeneral.TabIndex = 28;
            btnGenerarInformeGeneral.Text = "Generar Informe General";
            btnGenerarInformeGeneral.UseVisualStyleBackColor = true;
            btnGenerarInformeGeneral.Click += btnGenerarInformeGeneral_Click;
            // 
            // btnListarEmpleado
            // 
            btnListarEmpleado.Cursor = Cursors.Hand;
            btnListarEmpleado.FlatAppearance.BorderSize = 0;
            btnListarEmpleado.FlatStyle = FlatStyle.Flat;
            btnListarEmpleado.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnListarEmpleado.ForeColor = Color.Ivory;
            btnListarEmpleado.Location = new Point(625, 542);
            btnListarEmpleado.Margin = new Padding(4);
            btnListarEmpleado.Name = "btnListarEmpleado";
            btnListarEmpleado.Size = new Size(124, 31);
            btnListarEmpleado.TabIndex = 29;
            btnListarEmpleado.Text = "Listar Empleados";
            btnListarEmpleado.UseVisualStyleBackColor = true;
            btnListarEmpleado.Click += btnListarEmpleado_Click;
            // 
            // lbl11
            // 
            lbl11.AutoSize = true;
            lbl11.Cursor = Cursors.IBeam;
            lbl11.Font = new Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl11.ForeColor = Color.Ivory;
            lbl11.Location = new Point(1074, 90);
            lbl11.Margin = new Padding(4, 0, 4, 0);
            lbl11.Name = "lbl11";
            lbl11.Size = new Size(200, 25);
            lbl11.TabIndex = 30;
            lbl11.Text = "Registrar Permiso";
            // 
            // lblRegistrarPermiso
            // 
            lblRegistrarPermiso.AutoSize = true;
            lblRegistrarPermiso.Cursor = Cursors.IBeam;
            lblRegistrarPermiso.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblRegistrarPermiso.ForeColor = Color.Ivory;
            lblRegistrarPermiso.Location = new Point(923, 137);
            lblRegistrarPermiso.Margin = new Padding(4, 0, 4, 0);
            lblRegistrarPermiso.Name = "lblRegistrarPermiso";
            lblRegistrarPermiso.Size = new Size(177, 16);
            lblRegistrarPermiso.TabIndex = 31;
            lblRegistrarPermiso.Text = "Nombre del Empleado/Cédula";
            // 
            // txtEmpleadoPermiso
            // 
            txtEmpleadoPermiso.BackColor = Color.FromArgb(44, 62, 80);
            txtEmpleadoPermiso.Cursor = Cursors.IBeam;
            txtEmpleadoPermiso.ForeColor = Color.DarkGray;
            txtEmpleadoPermiso.Location = new Point(1106, 133);
            txtEmpleadoPermiso.Margin = new Padding(4);
            txtEmpleadoPermiso.Name = "txtEmpleadoPermiso";
            txtEmpleadoPermiso.PlaceholderText = "  Cedula/NombreCompleto";
            txtEmpleadoPermiso.Size = new Size(158, 24);
            txtEmpleadoPermiso.TabIndex = 32;
            // 
            // lbl12
            // 
            lbl12.AutoSize = true;
            lbl12.Cursor = Cursors.IBeam;
            lbl12.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl12.ForeColor = Color.Ivory;
            lbl12.Location = new Point(923, 172);
            lbl12.Margin = new Padding(4, 0, 4, 0);
            lbl12.Name = "lbl12";
            lbl12.Size = new Size(108, 16);
            lbl12.TabIndex = 33;
            lbl12.Text = "Inicio del Permiso";
            // 
            // lbl13
            // 
            lbl13.AutoSize = true;
            lbl13.Cursor = Cursors.IBeam;
            lbl13.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl13.ForeColor = Color.Ivory;
            lbl13.Location = new Point(923, 210);
            lbl13.Margin = new Padding(4, 0, 4, 0);
            lbl13.Name = "lbl13";
            lbl13.Size = new Size(95, 16);
            lbl13.TabIndex = 34;
            lbl13.Text = "Fin del Permiso";
            // 
            // lbl14
            // 
            lbl14.AutoSize = true;
            lbl14.Cursor = Cursors.IBeam;
            lbl14.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl14.ForeColor = Color.Ivory;
            lbl14.Location = new Point(923, 245);
            lbl14.Margin = new Padding(4, 0, 4, 0);
            lbl14.Name = "lbl14";
            lbl14.Size = new Size(115, 16);
            lbl14.TabIndex = 35;
            lbl14.Text = "Motivo del Permiso";
            // 
            // dtpInicioFechaPermiso
            // 
            dtpInicioFechaPermiso.Cursor = Cursors.Hand;
            dtpInicioFechaPermiso.Location = new Point(1126, 167);
            dtpInicioFechaPermiso.Margin = new Padding(4);
            dtpInicioFechaPermiso.Name = "dtpInicioFechaPermiso";
            dtpInicioFechaPermiso.Size = new Size(109, 24);
            dtpInicioFechaPermiso.TabIndex = 36;
            // 
            // dtpFinFechaPermiso
            // 
            dtpFinFechaPermiso.Cursor = Cursors.Hand;
            dtpFinFechaPermiso.Location = new Point(1126, 204);
            dtpFinFechaPermiso.Margin = new Padding(4);
            dtpFinFechaPermiso.Name = "dtpFinFechaPermiso";
            dtpFinFechaPermiso.Size = new Size(109, 24);
            dtpFinFechaPermiso.TabIndex = 37;
            // 
            // lbl15
            // 
            lbl15.AutoSize = true;
            lbl15.Cursor = Cursors.IBeam;
            lbl15.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl15.ForeColor = Color.Ivory;
            lbl15.Location = new Point(1261, 172);
            lbl15.Margin = new Padding(4, 0, 4, 0);
            lbl15.Name = "lbl15";
            lbl15.Size = new Size(68, 16);
            lbl15.TabIndex = 38;
            lbl15.Text = "Hora Inicio";
            // 
            // lbl16
            // 
            lbl16.AutoSize = true;
            lbl16.Cursor = Cursors.IBeam;
            lbl16.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl16.ForeColor = Color.Ivory;
            lbl16.Location = new Point(1261, 204);
            lbl16.Margin = new Padding(4, 0, 4, 0);
            lbl16.Name = "lbl16";
            lbl16.Size = new Size(55, 16);
            lbl16.TabIndex = 39;
            lbl16.Text = "Hora Fin";
            // 
            // dtpInicioHoraPermiso
            // 
            dtpInicioHoraPermiso.CustomFormat = "HH:mm:ss";
            dtpInicioHoraPermiso.Format = DateTimePickerFormat.Custom;
            dtpInicioHoraPermiso.Location = new Point(1334, 169);
            dtpInicioHoraPermiso.Margin = new Padding(4);
            dtpInicioHoraPermiso.Name = "dtpInicioHoraPermiso";
            dtpInicioHoraPermiso.Size = new Size(65, 24);
            dtpInicioHoraPermiso.TabIndex = 40;
            // 
            // dtpFinHoraPermiso
            // 
            dtpFinHoraPermiso.CustomFormat = "HH:mm:ss";
            dtpFinHoraPermiso.Format = DateTimePickerFormat.Custom;
            dtpFinHoraPermiso.Location = new Point(1334, 204);
            dtpFinHoraPermiso.Margin = new Padding(4);
            dtpFinHoraPermiso.Name = "dtpFinHoraPermiso";
            dtpFinHoraPermiso.Size = new Size(65, 24);
            dtpFinHoraPermiso.TabIndex = 41;
            // 
            // txtMotivoPermiso
            // 
            txtMotivoPermiso.BackColor = Color.FromArgb(44, 62, 80);
            txtMotivoPermiso.Cursor = Cursors.IBeam;
            txtMotivoPermiso.ForeColor = Color.DarkGray;
            txtMotivoPermiso.Location = new Point(1116, 245);
            txtMotivoPermiso.Margin = new Padding(4);
            txtMotivoPermiso.Name = "txtMotivoPermiso";
            txtMotivoPermiso.PlaceholderText = "  Motivo";
            txtMotivoPermiso.Size = new Size(128, 24);
            txtMotivoPermiso.TabIndex = 42;
            // 
            // chkPermisoPagado
            // 
            chkPermisoPagado.AutoSize = true;
            chkPermisoPagado.Cursor = Cursors.Hand;
            chkPermisoPagado.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkPermisoPagado.ForeColor = Color.Ivory;
            chkPermisoPagado.Location = new Point(1121, 284);
            chkPermisoPagado.Margin = new Padding(4);
            chkPermisoPagado.Name = "chkPermisoPagado";
            chkPermisoPagado.Size = new Size(125, 21);
            chkPermisoPagado.TabIndex = 43;
            chkPermisoPagado.Text = "Permiso Pagado";
            chkPermisoPagado.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarPermiso
            // 
            btnRegistrarPermiso.Cursor = Cursors.Hand;
            btnRegistrarPermiso.FlatAppearance.BorderSize = 0;
            btnRegistrarPermiso.FlatStyle = FlatStyle.Flat;
            btnRegistrarPermiso.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegistrarPermiso.ForeColor = Color.Ivory;
            btnRegistrarPermiso.Location = new Point(1121, 325);
            btnRegistrarPermiso.Margin = new Padding(4);
            btnRegistrarPermiso.Name = "btnRegistrarPermiso";
            btnRegistrarPermiso.Size = new Size(124, 31);
            btnRegistrarPermiso.TabIndex = 44;
            btnRegistrarPermiso.Text = "Registrar Permiso";
            btnRegistrarPermiso.UseVisualStyleBackColor = true;
            btnRegistrarPermiso.Click += btnRegistrarPermiso_Click;
            // 
            // CedulaColumn
            // 
            CedulaColumn.Name = "CedulaColumn";
            // 
            // NombreColumn
            // 
            NombreColumn.Name = "NombreColumn";
            // 
            // ApellidoColumn
            // 
            ApellidoColumn.Name = "ApellidoColumn";
            // 
            // CargoColumn
            // 
            CargoColumn.Name = "CargoColumn";
            // 
            // SalarioColumn
            // 
            SalarioColumn.Name = "SalarioColumn";
            // 
            // FechaIngresoColumn
            // 
            FechaIngresoColumn.Name = "FechaIngresoColumn";
            // 
            // dataGridViewEmpleados
            // 
            dataGridViewEmpleados.BackgroundColor = Color.FromArgb(44, 62, 80);
            dataGridViewEmpleados.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmpleados.Columns.AddRange(new DataGridViewColumn[] { CedulaColum, NombreColum, ApellidoColum, CargoColum, SalarioColum, FechaIngresoColum });
            dataGridViewEmpleados.Cursor = Cursors.Hand;
            dataGridViewEmpleados.Location = new Point(327, 590);
            dataGridViewEmpleados.Margin = new Padding(4);
            dataGridViewEmpleados.Name = "dataGridViewEmpleados";
            dataGridViewEmpleados.RowTemplate.Height = 25;
            dataGridViewEmpleados.Size = new Size(771, 149);
            dataGridViewEmpleados.TabIndex = 45;
            dataGridViewEmpleados.CellEndEdit += dataGridViewEmpleados_CellEndEdit;
            // 
            // CedulaColum
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CedulaColum.DefaultCellStyle = dataGridViewCellStyle1;
            CedulaColum.HeaderText = "Cédula";
            CedulaColum.MaxInputLength = 10;
            CedulaColum.Name = "CedulaColum";
            CedulaColum.Resizable = DataGridViewTriState.False;
            CedulaColum.Width = 120;
            // 
            // NombreColum
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            NombreColum.DefaultCellStyle = dataGridViewCellStyle2;
            NombreColum.HeaderText = "Nombre";
            NombreColum.Name = "NombreColum";
            NombreColum.Resizable = DataGridViewTriState.False;
            NombreColum.Width = 120;
            // 
            // ApellidoColum
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ApellidoColum.DefaultCellStyle = dataGridViewCellStyle3;
            ApellidoColum.HeaderText = "Apellido";
            ApellidoColum.Name = "ApellidoColum";
            ApellidoColum.Resizable = DataGridViewTriState.False;
            ApellidoColum.Width = 120;
            // 
            // CargoColum
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CargoColum.DefaultCellStyle = dataGridViewCellStyle4;
            CargoColum.HeaderText = "Cargo";
            CargoColum.Name = "CargoColum";
            CargoColum.Resizable = DataGridViewTriState.False;
            CargoColum.Width = 120;
            // 
            // SalarioColum
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            SalarioColum.DefaultCellStyle = dataGridViewCellStyle5;
            SalarioColum.HeaderText = "Salario";
            SalarioColum.Name = "SalarioColum";
            SalarioColum.Resizable = DataGridViewTriState.False;
            SalarioColum.Width = 120;
            // 
            // FechaIngresoColum
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FechaIngresoColum.DefaultCellStyle = dataGridViewCellStyle6;
            FechaIngresoColum.HeaderText = "Fecha de Ingreso";
            FechaIngresoColum.Name = "FechaIngresoColum";
            FechaIngresoColum.Resizable = DataGridViewTriState.False;
            FechaIngresoColum.Width = 130;
            // 
            // btnGenerarInformePermisos
            // 
            btnGenerarInformePermisos.Cursor = Cursors.Hand;
            btnGenerarInformePermisos.FlatAppearance.BorderSize = 0;
            btnGenerarInformePermisos.FlatStyle = FlatStyle.Flat;
            btnGenerarInformePermisos.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnGenerarInformePermisos.ForeColor = Color.Ivory;
            btnGenerarInformePermisos.Location = new Point(1087, 462);
            btnGenerarInformePermisos.Margin = new Padding(4);
            btnGenerarInformePermisos.Name = "btnGenerarInformePermisos";
            btnGenerarInformePermisos.Size = new Size(177, 31);
            btnGenerarInformePermisos.TabIndex = 46;
            btnGenerarInformePermisos.Text = "Generar Informe Permisos ";
            btnGenerarInformePermisos.UseVisualStyleBackColor = true;
            btnGenerarInformePermisos.Click += btnGenerarInformePermisos_Click;
            // 
            // backButton
            // 
            backButton.Cursor = Cursors.Hand;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Image = (Image)resources.GetObject("backButton.Image");
            backButton.Location = new Point(1377, 828);
            backButton.Margin = new Padding(4);
            backButton.Name = "backButton";
            backButton.Size = new Size(35, 37);
            backButton.TabIndex = 47;
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // btnRegistrarHuella
            // 
            btnRegistrarHuella.Cursor = Cursors.Hand;
            btnRegistrarHuella.FlatAppearance.BorderSize = 0;
            btnRegistrarHuella.FlatStyle = FlatStyle.Flat;
            btnRegistrarHuella.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegistrarHuella.ForeColor = Color.Ivory;
            btnRegistrarHuella.Location = new Point(178, 490);
            btnRegistrarHuella.Margin = new Padding(4);
            btnRegistrarHuella.Name = "btnRegistrarHuella";
            btnRegistrarHuella.Size = new Size(105, 32);
            btnRegistrarHuella.TabIndex = 48;
            btnRegistrarHuella.Text = "Registrar Huella";
            btnRegistrarHuella.UseVisualStyleBackColor = true;
            btnRegistrarHuella.Click += btnRegistrarHuella_Click;
            // 
            // txtEmpleadoID
            // 
            txtEmpleadoID.Cursor = Cursors.IBeam;
            txtEmpleadoID.Location = new Point(276, 452);
            txtEmpleadoID.Margin = new Padding(4);
            txtEmpleadoID.Name = "txtEmpleadoID";
            txtEmpleadoID.PlaceholderText = "  Cédula";
            txtEmpleadoID.Size = new Size(100, 24);
            txtEmpleadoID.TabIndex = 49;
            // 
            // LBL
            // 
            LBL.AutoSize = true;
            LBL.Cursor = Cursors.IBeam;
            LBL.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            LBL.ForeColor = Color.Ivory;
            LBL.Location = new Point(192, 454);
            LBL.Margin = new Padding(4, 0, 4, 0);
            LBL.Name = "LBL";
            LBL.Size = new Size(46, 16);
            LBL.TabIndex = 50;
            LBL.Text = "Cédula";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Cursor = Cursors.IBeam;
            label2.Font = new Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Ivory;
            label2.Location = new Point(178, 406);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(212, 25);
            label2.TabIndex = 51;
            label2.Text = "Registrar de Huella";
            // 
            // btnVerificarHuella
            // 
            btnVerificarHuella.Cursor = Cursors.Hand;
            btnVerificarHuella.FlatAppearance.BorderSize = 0;
            btnVerificarHuella.FlatStyle = FlatStyle.Flat;
            btnVerificarHuella.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerificarHuella.ForeColor = Color.Ivory;
            btnVerificarHuella.Location = new Point(290, 491);
            btnVerificarHuella.Margin = new Padding(4);
            btnVerificarHuella.Name = "btnVerificarHuella";
            btnVerificarHuella.Size = new Size(96, 30);
            btnVerificarHuella.TabIndex = 52;
            btnVerificarHuella.Text = "Verificar Huella";
            btnVerificarHuella.UseVisualStyleBackColor = true;
            btnVerificarHuella.Click += btnVerificarHuella_Click;
            // 
            // comboBoxTurno
            // 
            comboBoxTurno.Cursor = Cursors.Hand;
            comboBoxTurno.FormattingEnabled = true;
            comboBoxTurno.Location = new Point(270, 297);
            comboBoxTurno.Margin = new Padding(4);
            comboBoxTurno.Name = "comboBoxTurno";
            comboBoxTurno.Size = new Size(121, 24);
            comboBoxTurno.TabIndex = 53;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.IBeam;
            label3.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Ivory;
            label3.Location = new Point(204, 300);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(41, 16);
            label3.TabIndex = 54;
            label3.Text = "Turno";
            // 
            // btnGenerarInformeIndividual
            // 
            btnGenerarInformeIndividual.Cursor = Cursors.Hand;
            btnGenerarInformeIndividual.FlatAppearance.BorderSize = 0;
            btnGenerarInformeIndividual.FlatStyle = FlatStyle.Flat;
            btnGenerarInformeIndividual.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnGenerarInformeIndividual.ForeColor = Color.Ivory;
            btnGenerarInformeIndividual.Location = new Point(1186, 425);
            btnGenerarInformeIndividual.Margin = new Padding(4);
            btnGenerarInformeIndividual.Name = "btnGenerarInformeIndividual";
            btnGenerarInformeIndividual.Size = new Size(136, 31);
            btnGenerarInformeIndividual.TabIndex = 55;
            btnGenerarInformeIndividual.Text = "Generar Informe Individual";
            btnGenerarInformeIndividual.UseVisualStyleBackColor = true;
            btnGenerarInformeIndividual.Click += btnGenerarInformeIndividual_Click;
            // 
            // pictureBoxCerrar
            // 
            pictureBoxCerrar.Cursor = Cursors.Hand;
            pictureBoxCerrar.ErrorImage = Properties.Resources._4_removebg_preview;
            pictureBoxCerrar.Image = (Image)resources.GetObject("pictureBoxCerrar.Image");
            pictureBoxCerrar.InitialImage = Properties.Resources._4_removebg_preview;
            pictureBoxCerrar.Location = new Point(12, 12);
            pictureBoxCerrar.Name = "pictureBoxCerrar";
            pictureBoxCerrar.Size = new Size(24, 21);
            pictureBoxCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCerrar.TabIndex = 57;
            pictureBoxCerrar.TabStop = false;
            pictureBoxCerrar.Click += pictureBoxCerrar_Click;
            // 
            // pictureBoxMinimizar
            // 
            pictureBoxMinimizar.Cursor = Cursors.Hand;
            pictureBoxMinimizar.ErrorImage = Properties.Resources._4_removebg_preview;
            pictureBoxMinimizar.Image = (Image)resources.GetObject("pictureBoxMinimizar.Image");
            pictureBoxMinimizar.InitialImage = Properties.Resources._4_removebg_preview;
            pictureBoxMinimizar.Location = new Point(42, 12);
            pictureBoxMinimizar.Name = "pictureBoxMinimizar";
            pictureBoxMinimizar.Size = new Size(24, 21);
            pictureBoxMinimizar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMinimizar.TabIndex = 56;
            pictureBoxMinimizar.TabStop = false;
            pictureBoxMinimizar.Click += pictureBoxMinimizar_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(1424, 878);
            Controls.Add(pictureBoxCerrar);
            Controls.Add(pictureBoxMinimizar);
            Controls.Add(btnGenerarInformeIndividual);
            Controls.Add(label3);
            Controls.Add(comboBoxTurno);
            Controls.Add(btnVerificarHuella);
            Controls.Add(label2);
            Controls.Add(LBL);
            Controls.Add(txtEmpleadoID);
            Controls.Add(btnRegistrarHuella);
            Controls.Add(backButton);
            Controls.Add(btnGenerarInformePermisos);
            Controls.Add(dataGridViewEmpleados);
            Controls.Add(btnRegistrarPermiso);
            Controls.Add(chkPermisoPagado);
            Controls.Add(txtMotivoPermiso);
            Controls.Add(dtpFinHoraPermiso);
            Controls.Add(dtpInicioHoraPermiso);
            Controls.Add(lbl16);
            Controls.Add(lbl15);
            Controls.Add(dtpFinFechaPermiso);
            Controls.Add(dtpInicioFechaPermiso);
            Controls.Add(lbl14);
            Controls.Add(lbl13);
            Controls.Add(lbl12);
            Controls.Add(txtEmpleadoPermiso);
            Controls.Add(lblRegistrarPermiso);
            Controls.Add(lbl11);
            Controls.Add(btnListarEmpleado);
            Controls.Add(btnGenerarInformeGeneral);
            Controls.Add(lbl10);
            Controls.Add(btnActualizarSalario);
            Controls.Add(txtNuevoSalario);
            Controls.Add(lbl9);
            Controls.Add(txtActualizarEmpleado);
            Controls.Add(lblActualizarSalario);
            Controls.Add(lbl8);
            Controls.Add(btnEliminarEmpleado);
            Controls.Add(txtEliminarEmpleado);
            Controls.Add(lblEliminarEmpleado);
            Controls.Add(lbl7);
            Controls.Add(btnRegistrarEmpleado);
            Controls.Add(txtSalario);
            Controls.Add(txtApellido);
            Controls.Add(txtCargo);
            Controls.Add(txtCedula);
            Controls.Add(txtNombre);
            Controls.Add(lbl4);
            Controls.Add(dtpFechaIngreso);
            Controls.Add(lbl2);
            Controls.Add(lbl6);
            Controls.Add(lbl5);
            Controls.Add(lbl3);
            Controls.Add(lbl1);
            Controls.Add(label1);
            Controls.Add(lblRegistrarEmpleado);
            Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración";
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpleados).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRegistrarEmpleado;
        private Label label1;
        private Label lbl1;
        private Label lbl3;
        private Label lbl5;
        private Label lbl6;
        private Label lbl2;
        private DateTimePicker dtpFechaIngreso;
        private Label lbl4;
        private TextBox txtNombre;
        private TextBox txtCedula;
        private TextBox txtCargo;
        private TextBox txtSalario;
        private TextBox txtApellido;
        private Button btnRegistrarEmpleado;
        private Label lbl7;
        private Label lblEliminarEmpleado;
        private TextBox txtEliminarEmpleado;
        private Button btnEliminarEmpleado;
        private Label lbl8;
        private Label lblActualizarSalario;
        private TextBox txtActualizarEmpleado;
        private Label lbl9;
        private TextBox txtNuevoSalario;
        private Button btnActualizarSalario;
        private Label lbl10;
        private Button btnGenerarInformeGeneral;
        private Button btnListarEmpleado;
        private Label lbl11;
        private Label lblRegistrarPermiso;
        private TextBox txtEmpleadoPermiso;
        private Label lbl12;
        private Label lbl13;
        private Label lbl14;
        private DateTimePicker dtpInicioFechaPermiso;
        private DateTimePicker dtpFinFechaPermiso;
        private Label lbl15;
        private Label lbl16;
        private DateTimePicker dtpInicioHoraPermiso;
        private DateTimePicker dtpFinHoraPermiso;
        private TextBox txtMotivoPermiso;
        private CheckBox chkPermisoPagado;
        private Button btnRegistrarPermiso;
        private DataGridViewTextBoxColumn CedulaColumn;
        private DataGridViewTextBoxColumn NombreColumn;
        private DataGridViewTextBoxColumn ApellidoColumn;
        private DataGridViewTextBoxColumn CargoColumn;
        private DataGridViewTextBoxColumn SalarioColumn;
        private DataGridViewTextBoxColumn FechaIngresoColumn;
        private DataGridView dataGridViewEmpleados;
        private Button btnGenerarInformePermisos;
        private Button backButton;
        private DataGridViewTextBoxColumn CedulaColum;
        private DataGridViewTextBoxColumn NombreColum;
        private DataGridViewTextBoxColumn ApellidoColum;
        private DataGridViewTextBoxColumn CargoColum;
        private DataGridViewTextBoxColumn SalarioColum;
        private DataGridViewTextBoxColumn FechaIngresoColum;
        private Button btnRegistrarHuella;
        private TextBox txtEmpleadoID;
        private Label LBL;
        private Label label2;
        private Button btnVerificarHuella;
        private ComboBox comboBoxTurno;
        private Label label3;
        private Button btnGenerarInformeIndividual;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBoxCerrar;
        private PictureBox pictureBoxMinimizar;
    }
}