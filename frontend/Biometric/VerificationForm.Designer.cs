namespace UI_Support
{
    partial class VerificationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblPrompt; // Define lblPrompt aquí
        private Button CloseButton; // Define CloseButton aquí
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerificationForm));
            VerificationControl = new DPFP.Gui.Verification.VerificationControl();
            CloseButton = new Button();
            lblPrompt = new Label();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.DialogResult = DialogResult.OK;
            CloseButton.Location = new Point(257, 87);
            CloseButton.Margin = new Padding(4, 3, 4, 3);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(88, 27);
            CloseButton.TabIndex = 2;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // VerificationControl
            // 
            VerificationControl.Active = true;
            VerificationControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            VerificationControl.Location = new Point(15, 15);
            VerificationControl.Margin = new Padding(5, 3, 5, 3);
            VerificationControl.Name = "VerificationControl";
            VerificationControl.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
            VerificationControl.Size = new Size(56, 54);
            VerificationControl.TabIndex = 4;
            VerificationControl.OnComplete += OnComplete;
            // 
            // lblPrompt
            // 
            lblPrompt.Location = new Point(78, 15);
            lblPrompt.Margin = new Padding(4, 0, 4, 0);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(266, 50);
            lblPrompt.TabIndex = 5;
            lblPrompt.Text = "To verify your identity, touch fingerprint reader with any enrolled finger.";
            // 
            // VerificationForm
            // 
            AcceptButton = CloseButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CloseButton;
            ClientSize = new Size(358, 127);
            Controls.Add(VerificationControl);
            Controls.Add(lblPrompt);
            Controls.Add(CloseButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VerificationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Verify Your Identity";
            ResumeLayout(false);
        }

        #endregion

        private DPFP.Gui.Verification.VerificationControl VerificationControl;

	}
}