using SystemGestionAplication.backend.Database;
using SystemGestionAplication.frontend;

namespace SystemGestionAplication
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            
            ApplicationConfiguration.Initialize();
            MongoDBConnection.InitializeDatabase();
            using (SplashForm splashForm = new SplashForm())
            {
                splashForm.ShowDialog(); // Mostrar como cuadro de diálogo modal
            }
            LoginForm loginForm = new LoginForm();
            Application.Run(new MainForm());
        }
    }
}