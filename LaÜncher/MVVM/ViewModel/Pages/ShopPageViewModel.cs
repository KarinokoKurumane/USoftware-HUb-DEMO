using System.ComponentModel;
using USoftware_HUb.MVVM.Utility;

namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    class ShopPageViewModel : ObservableObject
    {
        private static ShopPageViewModel? _instance;
        public static ShopPageViewModel Instance => _instance ??= new ShopPageViewModel();

        private ShopPageViewModel()
        {

        }
    }
}
