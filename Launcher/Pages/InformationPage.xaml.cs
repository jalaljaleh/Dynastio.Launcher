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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launcher.Pages
{
    /// <summary>
    /// Interaction logic for InformationPage.xaml
    /// </summary>
    public partial class InformationPage : Page
    {
        public InformationPage()
        {
            InitializeComponent();
        }

        private void BtnOpenSource_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://discord.gg/GVUXMNv7vV");

        }

        private void BtnItch_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://discord.gg/GVUXMNv7vV");

        }

        private void BtnDiscord_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://discord.gg/GVUXMNv7vV");
        }
    }
}
