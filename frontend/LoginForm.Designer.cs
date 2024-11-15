namespace SystemGestionAplication.frontend
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            backButton = new Button();
            passwordTogglePictureBox = new PictureBox();
            usernameTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)passwordTogglePictureBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Ivory;
            label1.Location = new Point(248, 46);
            label1.Name = "label1";
            label1.Size = new Size(89, 33);
            label1.TabIndex = 0;
            label1.Text = "Login";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(44, 62, 80);
            passwordTextBox.Cursor = Cursors.IBeam;
            passwordTextBox.ForeColor = Color.DarkGray;
            passwordTextBox.Location = new Point(216, 152);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(150, 24);
            passwordTextBox.TabIndex = 2;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.Enter += passwordTextBox_Enter;
            passwordTextBox.Leave += passwordTextBox_Leave;
            // 
            // loginButton
            // 
            loginButton.Cursor = Cursors.Hand;
            loginButton.FlatAppearance.BorderColor = Color.FromArgb(44, 62, 80);
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.ForeColor = Color.Ivory;
            loginButton.Location = new Point(244, 195);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(100, 27);
            loginButton.TabIndex = 3;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // backButton
            // 
            backButton.Cursor = Cursors.Hand;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Image = (Image)resources.GetObject("backButton.Image");
            backButton.Location = new Point(524, 338);
            backButton.Name = "backButton";
            backButton.Size = new Size(35, 35);
            backButton.TabIndex = 4;
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // passwordTogglePictureBox
            // 
            passwordTogglePictureBox.BackColor = Color.Transparent;
            passwordTogglePictureBox.BackgroundImageLayout = ImageLayout.None;
            passwordTogglePictureBox.Cursor = Cursors.Hand;
            passwordTogglePictureBox.ErrorImage = null;
            passwordTogglePictureBox.Image = Properties.Resources.eye_closed;
            passwordTogglePictureBox.InitialImage = null;
            passwordTogglePictureBox.Location = new Point(332, 154);
            passwordTogglePictureBox.Name = "passwordTogglePictureBox";
            passwordTogglePictureBox.Size = new Size(29, 20);
            passwordTogglePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            passwordTogglePictureBox.TabIndex = 5;
            passwordTogglePictureBox.TabStop = false;
            passwordTogglePictureBox.Click += passwordTogglePictureBox_Click;
            // 
            // usernameTextBox
            // 
            usernameTextBox.BackColor = Color.FromArgb(44, 62, 80);
            usernameTextBox.Cursor = Cursors.IBeam;
            usernameTextBox.ForeColor = Color.DarkGray;
            usernameTextBox.Location = new Point(216, 96);
            usernameTextBox.Margin = new Padding(4);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "  Username";
            usernameTextBox.Size = new Size(150, 24);
            usernameTextBox.TabIndex = 59;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(584, 385);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordTogglePictureBox);
            Controls.Add(backButton);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(label1);
            Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)passwordTogglePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Button backButton;
        private PictureBox passwordTogglePictureBox;
        private TextBox usernameTextBox;
    }
}