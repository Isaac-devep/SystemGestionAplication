using System;
using System.Collections.Generic;
using System.Text;
using DPFP;

namespace UI_Support
{
    public delegate void OnChangeHandler();

    // Keeps application-wide data shared among forms and provides notifications about changes
    //
    // Everywhere in this application a "document-view" model is used, and this class provides
    // a "document" part, whereas forms implement a "view" parts.
    // Each form interested in this data keeps a reference to it and synchronizes it with own 
    // controls using the OnChange() event and the Update() notificator method.
    //
    public class AppData
    {
        public const int MaxFingers = 10;

        // Datos compartidos originales
        public int EnrolledFingersMask = 0;
        public int MaxEnrollFingerCount = MaxFingers;
        public bool IsEventHandlerSucceeds = true;
        public bool IsFeatureSetMatched = false;
        public int FalseAcceptRate = 0;
        public Template[] Templates = new Template[MaxFingers];

        // Nuevos campos para seguimiento de sesión y calidad
        public string SessionId { get; set; } = string.Empty;
        public DateTime RegistrationTime { get; set; } = DateTime.Now;
        public int CurrentFingerIndex { get; set; } = -1;
        public string CaptureQuality { get; set; } = string.Empty;
        public string DeviceSerialNumber { get; set; } = string.Empty;

        // Información adicional de registro
        public class RegistrationInfo
        {
            public int AttemptCount { get; set; } = 0;
            public bool IsCompleted { get; set; } = false;
            public DateTime LastAttemptTime { get; set; } = DateTime.Now;
            public string LastQualityFeedback { get; set; } = string.Empty;
        }

        public RegistrationInfo CurrentRegistration { get; set; } = new RegistrationInfo();

        // Notificación de cambio de datos
        public void Update()
        {
            OnChange?.Invoke();  // Solo llama a OnChange si tiene suscriptores
        }

        // Métodos de utilidad para el registro
        public void InitializeNewSession()
        {
            SessionId = Guid.NewGuid().ToString();
            RegistrationTime = DateTime.Now;
            CurrentFingerIndex = -1;
            CaptureQuality = string.Empty;
            CurrentRegistration = new RegistrationInfo();
            Update();
        }

        public void UpdateRegistrationProgress(int fingerIndex, string quality)
        {
            CurrentFingerIndex = fingerIndex;
            CaptureQuality = quality;
            CurrentRegistration.AttemptCount++;
            CurrentRegistration.LastAttemptTime = DateTime.Now;
            CurrentRegistration.LastQualityFeedback = quality;
            Update();
        }

        public void CompleteRegistration()
        {
            CurrentRegistration.IsCompleted = true;
            CurrentRegistration.LastAttemptTime = DateTime.Now;
            Update();
        }

        public event OnChangeHandler OnChange;
    }
}