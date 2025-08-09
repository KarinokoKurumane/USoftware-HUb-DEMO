using System.Windows.Controls;
using USoftware_HUb.MVVM.ViewModel.Pages;
using USoftwareHUB.Models;
using USoftwareHUB.Services;

namespace USoftware_HUb.MVVM.Views.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : UserControl
    {
        public ProfilePage()
        {
            InitializeComponent();

            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            loggerService!.Log("Initialize Component Done", LogTagType.INFO, "ProfilePage .ctor");

            DataContext = ProfilePagesViewModel.Instance;
        }
    }
}
