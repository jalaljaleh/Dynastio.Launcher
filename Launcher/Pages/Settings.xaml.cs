using System;
using System.Collections.Generic;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }

        private async void BtnBlackSkin_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            try
            {
                DynastioSettings.ChangeSkinColor();
                (sender as Button).Content = "Skin Changed";
            }
            catch
            {
                await Task.Delay(1000);
                (sender as Button).Content = "Unkown Error";
                (sender as Button).IsEnabled = true;
            }
        }

        private async void BtnDeleteSettings_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            try
            {
                DynastioSettings.DeleteDynastioRegistry();
                (sender as Button).Content = "Settings Deleted";
            }
            catch
            {
                (sender as Button).Content = "Unkown Error";
                await Task.Delay(1000);
            }

        }

        private async void BtnChangeNickname_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            try
            {
                DynastioSettings.ChangeNickname(TbNickname.Text);
                (sender as Button).Content = "Changeed";
                await Task.Delay(500);
                (sender as Button).Content = "Change";

            }
            catch
            {
                (sender as Button).Content = "Unkown Error";
                await Task.Delay(2000);
            }

            (sender as Button).IsEnabled = true;
        }
    }
}
