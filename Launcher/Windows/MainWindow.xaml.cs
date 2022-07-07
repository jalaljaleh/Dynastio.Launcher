using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Launcher.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pages.Home home;
        public MainWindow()
        {
            InitializeComponent();
            home = new Pages.Home();
            this.FrameMain.Content = home;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) this.DragMove();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e) => this.FrameMain.Content = home;
        private void BtnSettings_Click(object sender, RoutedEventArgs e) => this.FrameMain.Content = new Pages.Settings();
        private void BtnDynastioChangeLog_Click(object sender, RoutedEventArgs e) => this.FrameMain.Content = new Pages.ChangeLogPage();
        private void BtnInfo_Click(object sender, RoutedEventArgs e) => this.FrameMain.Content = new Pages.InformationPage();


        private void BtnDiscord_Click(object sender, RoutedEventArgs e) => Process.Start(App.Configuration.urlDiscord);
        private void BtnYoutube_Click(object sender, RoutedEventArgs e) => Process.Start(App.Configuration.urlYoutube);
        private void BtnVk_Click(object sender, RoutedEventArgs e) => Process.Start(App.Configuration.urlVk);
        private void BtnVersion_Click(object sender, RoutedEventArgs e) => Process.Start(App.Configuration.urlLauncherVersion);

        private void BtnExit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

    }
}
