using System.Windows.Controls;
using USoftware_HUb.MVVM.ViewModel.Pages;
using USoftwareHUB.Models;
using USoftwareHUB.Services;

namespace USoftware_HUb.MVVM.Views.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy ShopPage.xaml
    /// </summary>
    public partial class ShopPage : UserControl
    {
        public ShopPage()
        {
            InitializeComponent();

            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            loggerService!.Log("Initialize Component Done", LogTagType.INFO, "ShopPage .ctor");

            DataContext = ShopPageViewModel.Instance;
        }
    }
}
