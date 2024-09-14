namespace WinFormsApp2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // Inisialisasi konfigurasi aplikasi
            ApplicationConfiguration.Initialize();

            // Aktifkan visual styles dan rendering default
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tampilkan Splash Screen
            using (var splash = new SplashScreen())
            {
                splash.ShowDialog();
            }

            // Tampilkan Form Utama setelah Splash Screen
            Application.Run(new Form1());
        }
    }
}