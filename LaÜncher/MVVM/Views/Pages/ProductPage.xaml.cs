using System.Windows.Controls;
using USoftware_HUb.MVVM.ViewModel.Pages;
using USoftwareHUB.Models;
using USoftwareHUB.Services;

namespace USoftware_HUb.MVVM.Views.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy ProductPage.xaml
    /// </summary>
    public partial class ProductPage : UserControl
    {
        public ProductPage()
        {
            InitializeComponent();

            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            loggerService!.Log("Initialize Component Done", LogTagType.INFO, "ProductPage .ctor");

            DataContext = ProductPageViewModel.Instance;
        }
    }
}
