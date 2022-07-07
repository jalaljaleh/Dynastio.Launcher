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
using Launcher;
namespace Launcher.Pages
{
    /// <summary>
    /// Interaction logic for ChangeLogPage.xaml
    /// </summary>
    public partial class ChangeLogPage : Page
    {
        public ChangeLogPage()
        {
            InitializeComponent();
            Intialize();
           
        }
        List<string> Pages = new List<string>();
        int Page = 0;
        public async void Intialize()
        {
            LabelContent.Text = "Loading ..";
            string txt = await ConnectionManager.GetChangeLogAsync(App.Configuration.urlChangeLog);
            Pages = txt.Split(new[] { "\n\r" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            GoToPage(Page);
        }
        public void GoToPage(int page)
        {
            LabelContent.Text = Pages.Skip(page).FirstOrDefault() ?? "Not found.";
        }
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            Page++;
            GoToPage(Page);
        }

        private async void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Intialize();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Page--;
            GoToPage(Page);
        }
    }
}
