using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.IO;
using System.Windows.Forms;
using SystemGestionAplication.backend.Controllers;
using SystemGestionAplication.backend.Database;

namespace UI_Support
{
    public partial class VerificationForm : Form
    {
        private byte[] huellaAlmacenada;
        private System.Windows.Forms.Timer closeTimer; // Declara el temporizador como un campo de clase
        public event Action<string> OnVerificationComplete; // Evento para indicar que la verificación fue completada
        private string cedulaEmpleado;
        public VerificationForm(AppData data, string cedula)
        {
            InitializeComponent();
            Data = data;
            CargarHuellaPorCedula(cedula);

            cedulaEmpleado = cedula; // Asigna la cédula al campo de la clase

            // Inicializar el temporizador
            closeTimer = new System.Windows.Forms.Timer();
            closeTimer.Interval = 2000; // 2000 milisegundos = 2 segundos
            closeTimer.Tick += CloseTimer_Tick;
        }

        private void CargarHuellaPorCedula(string cedula)
        {
            var collection = MongoDBConnection.EmpleadosCollection;
            var filter = Builders<BsonDocument>.Filter.Eq("cedula", cedula);
            var empleado = collection.Find(filter).FirstOrDefault();

            if (empleado != null && empleado.Contains("huella"))
            {
                huellaAlmacenada = empleado["huella"].AsByteArray;
            }
            else
            {
                MessageBox.Show("No se encontró una huella registrada para esta cédula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Invoca el evento indicando que la verificación ha fallado
                OnVerificationComplete?.Invoke("fallo");

                // Cierra el formulario después de notificar la falla
                this.Close();
            }
        }

        public void OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus Status)
        {
            if (huellaAlmacenada == null)
            {
                Status = DPFP.Gui.EventHandlerStatus.Failure;
                lblPrompt.Text = "No se encontró una huella registrada para la cédula proporcionada.";
                lblPrompt.ForeColor = System.Drawing.Color.Red;
                return;
            }

            DPFP.Verification.Verification ver = new DPFP.Verification.Verification();
            DPFP.Verification.Verification.Result res = new DPFP.Verification.Verification.Result();

            // Crear una plantilla a partir de la huella almacenada
            DPFP.Template templateAlmacenado = new DPFP.Template(new MemoryStream(huellaAlmacenada));

            // Comparar la huella escaneada con la huella almacenada
            ver.Verify(FeatureSet, templateAlmacenado, ref res);
            Data.IsFeatureSetMatched = res.Verified;
            Data.FalseAcceptRate = res.FARAchieved;

            if (res.Verified)
            {
                lblPrompt.Text = "Verificación exitosa.";
                lblPrompt.ForeColor = System.Drawing.Color.Green;
                Status = DPFP.Gui.EventHandlerStatus.Success;

                // Completar la verificación como éxito
                CompleteVerification(true);
            }
            else
            {
                lblPrompt.Text = "Huella no verificada.";
                lblPrompt.ForeColor = System.Drawing.Color.Red;
                Status = DPFP.Gui.EventHandlerStatus.Failure;

                // Completar la verificación como fallo
                CompleteVerification(false);
            }

            Data.Update();
        }

        private void CompleteVerification(bool success)
        {
            // Determinar el tipo de registro (entrada o salida)
            string tipoRegistro = success ? "entrada" : "salida";

            // Asegúrate de que `cedulaEmpleado` esté declarada en la clase `VerificationForm` y asignada con el valor correcto
            if (string.IsNullOrEmpty(cedulaEmpleado))
            {
                MessageBox.Show("No se ha especificado la cédula del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llamar al método para registrar en la base de datos
            string mensaje = EmployeeController.RegistrarEntradaOSalida(tipoRegistro, cedulaEmpleado);

            // Mostrar el resultado en la UI
            OnVerificationComplete?.Invoke(mensaje);

            // Cerrar el formulario después de invocar el evento
            this.Close();
        }
        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            closeTimer.Stop(); // Detener el temporizador para que no se ejecute repetidamente
            this.Close(); // Cerrar el formulario
        }

        private AppData Data;
    }
}