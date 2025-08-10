using USoftwareHUB.Utility;

namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    class ShopPageViewModel : ObservableObject
    {
        private Uri _shopUrl = new Uri("https://karinokokurumane.github.io/USoftware-HUb-DEMO");

        public Uri ShopUrl
        {
            get => _shopUrl;
            set => SetProperty(ref _shopUrl, value);
        }

        private static ShopPageViewModel? _instance;
        public static ShopPageViewModel Instance => _instance ??= new ShopPageViewModel();

        private ShopPageViewModel()
        {

        }
    }
}
