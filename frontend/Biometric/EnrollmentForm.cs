using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DPFP;

namespace UI_Support
{
    public partial class EnrollmentForm : Form
    {
        private AppData Data;
        private DPFP.Template currentTemplate;

        // Constructor
        public EnrollmentForm(AppData data)
        {
            InitializeComponent();
            Data = data;                                       // Keep reference to the data
            ExchangeData(true);                                // Init data with default control values;
            Data.OnChange += delegate { ExchangeData(false); }; // Track data changes to keep the form synchronized

            // Configurar el control de enrolamiento
            EnrollmentControl.EnrolledFingerMask = 0;
            EnrollmentControl.MaxEnrollFingerCount = 1;
            EnrollmentControl.OnEnroll += EnrollmentControl_OnEnroll;
        }

        // Simple dialog data exchange (DDX) implementation.
        public void ExchangeData(bool read)
        {
            if (read)
            {    // Read values from the form's controls to the data object
                Data.EnrolledFingersMask = EnrollmentControl.EnrolledFingerMask;
                Data.MaxEnrollFingerCount = EnrollmentControl.MaxEnrollFingerCount;
                Data.Update();
            }
            else
            {    // Read values from the data object to the form's controls
                EnrollmentControl.EnrolledFingerMask = Data.EnrolledFingersMask;
                EnrollmentControl.MaxEnrollFingerCount = Data.MaxEnrollFingerCount;
            }
        }

        // Event handling
        public void EnrollmentControl_OnEnroll(Object Control, int Finger, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus Status)
        {
            try
            {
                if (Template != null)
                {
                    currentTemplate = Template;
                    Data.Templates[Finger - 1] = Template;         // Store a finger template
                    ExchangeData(true);                            // Update other data
                    DialogResult = DialogResult.OK;                // Close the form successfully
                    this.Close();
                }
                else
                {
                    Status = DPFP.Gui.EventHandlerStatus.Failure; // Force a "failure" status
                }
            }
            catch (Exception)
            {
                Status = DPFP.Gui.EventHandlerStatus.Failure;
            }
        }

        public void EnrollmentControl_OnDelete(Object Control, int Finger, ref DPFP.Gui.EventHandlerStatus Status)
        {
            if (Data.IsEventHandlerSucceeds)
            {
                Data.Templates[Finger - 1] = null;             // Clear the finger template
                ExchangeData(true);                            // Update other data
                ListEvents.Items.Insert(0, String.Format("OnDelete: finger {0}", Finger));
            }
            else
            {
                Status = DPFP.Gui.EventHandlerStatus.Failure; // Force a "failure" status
            }
        }

        private void EnrollmentControl_OnCancelEnroll(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnCancelEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnReaderConnect(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnReaderConnect: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnReaderDisconnect(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnReaderDisconnect: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnStartEnroll(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnStartEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnFingerRemove(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnFingerRemove: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnFingerTouch(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnFingerTouch: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnSampleQuality(object Control, string ReaderSerialNumber, int Finger, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            ListEvents.Items.Insert(0, String.Format("OnSampleQuality: {0}, finger {1}, {2}", ReaderSerialNumber, Finger, CaptureFeedback));
        }

        private void EnrollmentControl_OnComplete(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnComplete: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        // Método para obtener el template de huella
        public DPFP.Template ObtenerTemplate()
        {
            // Retornar el template actual
            return Data.Templates.FirstOrDefault(t => t != null);
        }

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {
            this.ListEvents.Items.Clear();
        }
    }
}
