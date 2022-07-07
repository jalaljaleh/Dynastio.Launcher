using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launcher.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Home : Page
    {
     
        public Home()
        {
            InitializeComponent();
            Initialize();
        }
        WebClient wc;
        Version version = new Version() { };
        async void Initialize()
        {
            this.IsEnabled = false;
            try
            {
                LabelNotification.Text = "";
                this.BtnPlay.Content = "Checking for update..";

                version = await ConnectionManager.GetVersionAsync(App.Configuration.urlVersion);
                if (version == null)
                {
                    LabelNotification.Text = "Connection problem, try again.";
                    this.BtnPlay.Content = "Try again";
                    return;
                }
                if (!File.Exists(PathManager.Dynastio))
                {
                    LabelNotification.Text = "Dynast.io is not installed, click to install.";
                    this.BtnPlay.Content = "Install Dynast.io";
                    return;
                }


                var currentVersion = File.ReadAllText(PathManager.Version);
                if (currentVersion != version.version)
                {
                    LabelNotification.Text = "New version available, click to install.";
                    this.BtnPlay.Content = "Update Dynast.io";
                    return;
                }

                this.BtnPlay.Content = "Play";
            }
            finally
            {
                this.IsEnabled = true;
                this.BtnPlay.IsEnabled = true;
            }
        }
        public void PlayDynastio()
        {
            try
            {
                bool includePrivate = this.CbIncludePrivateServers.IsChecked.HasValue && this.CbIncludePrivateServers.IsChecked.Value;
                using (Process dynastio = new Process())
                {
                    dynastio.StartInfo.FileName = PathManager.Dynastio;
                    dynastio.StartInfo.Arguments = includePrivate ? "include-custom true" : "";
                    dynastio.Start();
                    dynastio.WaitForExit();
                }
            }
            catch
            {
                LabelNotification.Text = "Can't open dynast.io.";
            }
         
        }


        public void InstallDynastio()
        {
            this.BtnPlay.IsEnabled = false;
            try
            {
                LabelNotification.Text = "Installing latest version ..";
                this.BtnPlay.Content = "Preparing ...";

                if (!Directory.Exists(PathManager.Bin))
                    Directory.CreateDirectory(PathManager.Bin);

                if (File.Exists(PathManager.DownloadGame))
                {
                    File.Delete(PathManager.DownloadGame);
                }

                //if the game is open
                this.BtnPlay.Content = "Closing Dynastio..";
                foreach (Process proc in Process.GetProcessesByName("dynast.io.exe"))
                    proc.Kill();

                if (Directory.Exists(PathManager.Game))
                    Directory.Delete(PathManager.Game, true);
                Directory.CreateDirectory(PathManager.Game);

                this.BtnPlay.Content = "Prepaing download..";
                wc = new WebClient();
                wc.Headers[HttpRequestHeader.UserAgent] = "Dynastio.Launcher 0.1v";
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted; ;
                wc.DownloadFileAsync(new Uri(version.url), PathManager.DownloadGame);


            }
            catch
            {
                LabelNotification.Text = "Can't download dynast.io.";
                Initialize();
            }

        }

        private void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                this.BtnPlay.Content = "Installing...";
                ZipFile.ExtractToDirectory(PathManager.DownloadGame, PathManager.Game);
                this.BtnPlay.Content = "Dynast.io Installed";
                Task.Delay(4000).GetAwaiter().GetResult();
            }
            catch
            {
                LabelNotification.Text = "Can't extract dynast.io.";
            }
            Initialize();
        }


        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Dispatcher.Invoke(() => this.BtnPlay.Content = string.Format("{0} of {1} downloaded..", e.BytesReceived.ToSizeSuffix(), e.TotalBytesToReceive.ToSizeSuffix()));
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Content)
            {
                case "Play":
                    PlayDynastio();
                    break;
                case "Update Dynast.io":
                case "Install Dynast.io":
                    InstallDynastio();
                    break;
                case "Try again":
                    Initialize();
                    break;

                default:
                    LabelNotification.Text = "What to do ?";
                    break;
            }
        }


    }
}
