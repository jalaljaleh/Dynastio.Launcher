
using System.Windows;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Configuration Configuration { get; set; }
        public App()
        {
           

            this.InitializeComponent();
            Configuration = Configuration.GetConfiguration();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = new Windows.MainWindow();
            mainWindow.Show();
        }
     
    }
}
