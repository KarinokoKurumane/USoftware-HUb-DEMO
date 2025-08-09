using System.Windows.Controls;
using USoftware_HUb.MVVM.ViewModel.Pages;
using USoftwareHUB.Models;
using USoftwareHUB.Services;

namespace USoftware_HUb.MVVM.Views.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy HelpPage.xaml
    /// </summary>
    public partial class HelpPage : UserControl
    {
        public HelpPage()
        {
            InitializeComponent();

            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            loggerService!.Log("Initialize Component Done", LogTagType.INFO, "HelpPage .ctor");

            DataContext = HelpPageViewModel.Instance;
        }
    }
}
