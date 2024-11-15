namespace UI_Support
{
    partial class EnrollmentForm
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
            Button CloseButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnrollmentForm));
            EnrollmentControl = new DPFP.Gui.Enrollment.EnrollmentControl();
            GroupEvents = new GroupBox();
            ListEvents = new ListBox();
            CloseButton = new Button();
            GroupEvents.SuspendLayout();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.DialogResult = DialogResult.OK;
            CloseButton.Location = new Point(410, 474);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 1;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // EnrollmentControl
            // 
            EnrollmentControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            EnrollmentControl.EnrolledFingerMask = 0;
            EnrollmentControl.Location = new Point(2, -3);
            EnrollmentControl.Margin = new Padding(4, 3, 4, 3);
            EnrollmentControl.MaxEnrollFingerCount = 10;
            EnrollmentControl.Name = "EnrollmentControl";
            EnrollmentControl.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
            EnrollmentControl.Size = new Size(492, 314);
            EnrollmentControl.TabIndex = 2;
            EnrollmentControl.OnDelete += EnrollmentControl_OnDelete;
            EnrollmentControl.OnEnroll += EnrollmentControl_OnEnroll;
            EnrollmentControl.OnFingerTouch += EnrollmentControl_OnFingerTouch;
            EnrollmentControl.OnFingerRemove += EnrollmentControl_OnFingerRemove;
            EnrollmentControl.OnComplete += EnrollmentControl_OnComplete;
            EnrollmentControl.OnReaderConnect += EnrollmentControl_OnReaderConnect;
            EnrollmentControl.OnReaderDisconnect += EnrollmentControl_OnReaderDisconnect;
            EnrollmentControl.OnSampleQuality += EnrollmentControl_OnSampleQuality;
            EnrollmentControl.OnStartEnroll += EnrollmentControl_OnStartEnroll;
            EnrollmentControl.OnCancelEnroll += EnrollmentControl_OnCancelEnroll;
            // 
            // GroupEvents
            // 
            GroupEvents.Controls.Add(ListEvents);
            GroupEvents.Location = new Point(12, 317);
            GroupEvents.Name = "GroupEvents";
            GroupEvents.Size = new Size(473, 146);
            GroupEvents.TabIndex = 3;
            GroupEvents.TabStop = false;
            GroupEvents.Text = "Events";
            // 
            // ListEvents
            // 
            ListEvents.BackColor = SystemColors.InactiveBorder;
            ListEvents.FormattingEnabled = true;
            ListEvents.ItemHeight = 15;
            ListEvents.Location = new Point(16, 19);
            ListEvents.Name = "ListEvents";
            ListEvents.Size = new Size(440, 94);
            ListEvents.TabIndex = 0;
            // 
            // EnrollmentForm
            // 
            AcceptButton = CloseButton;
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = CloseButton;
            ClientSize = new Size(497, 509);
            Controls.Add(GroupEvents);
            Controls.Add(CloseButton);
            Controls.Add(EnrollmentControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EnrollmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fingerprint Enrollment";
            Load += EnrollmentForm_Load;
            GroupEvents.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public DPFP.Gui.Enrollment.EnrollmentControl EnrollmentControl;
        private System.Windows.Forms.GroupBox GroupEvents;
        private System.Windows.Forms.ListBox ListEvents;
    }
}