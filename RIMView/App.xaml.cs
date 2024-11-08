using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

namespace RIMView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if(e.Args.Length != 1)
            {
                MessageBox.Show("Failed to load RIM file: No argument provided", "RIMView");
                Environment.Exit(-1);
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            mainWindow.SetLoading(true);

            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RIMView", "Temp")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RIMView", "Temp"));
            }

            string location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RIMView", "Temp", new Guid().ToString() + ".bmp");

            try
            {
                Process process = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "RIMTils", "RIMTils.exe"),
                        Arguments = $"convert -m ToBMP -f \"{e.Args[0]}\" -t \"{location}\"",
                        CreateNoWindow = true
                    }
                };

                process.Start();
                process.WaitForExit();

                mainWindow.SetLoading(false);
                mainWindow.SetImage(location);
            } catch (Exception ex)
            {
                mainWindow.Hide();
                MessageBox.Show($"Failed to load RIM file: {ex.Message}", "RIMView");
                Environment.Exit(-1);
            }
        }
    }
}
