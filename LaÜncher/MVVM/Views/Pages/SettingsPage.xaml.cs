using System.Windows.Controls;
using USoftware_HUb.MVVM.ViewModel.Pages;
using USoftwareHUB.Models;
using USoftwareHUB.Services;

namespace USoftware_HUb.MVVM.Views.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();

            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            loggerService!.Log("Initialize Component Done", LogTagType.INFO, "SettingsPage .ctor");

            DataContext = SettingsPageViewModel.Instance;
        }
    }
}
