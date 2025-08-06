using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using USoftware_HUb.MVVM.Models;
using USoftware_HUb.MVVM.Utility;
using USoftwareHUB.Utility;

namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    class ProductPageViewModel : ObservableObject
    {
        public ObservableCollection<ProductItem> DisplayItems { get; set; } = new();

        public ICommand ShowProgramsCommand { get; }
        public ICommand ShowGamesCommand { get; }
        public ICommand AddProductCommand { get; }

        


        private bool _isDownloading;
        public bool IsDownloading
        {
            get => _isDownloading;
            set { _isDownloading = value; OnPropertyChanged(nameof(IsDownloading)); }
        }

        private double _downloadProgress;
        public double DownloadProgress
        {
            get => _downloadProgress;
            set { _downloadProgress = value; OnPropertyChanged(nameof(DownloadProgress)); }
        }

        private static ProductPageViewModel? _instance;
        public static ProductPageViewModel Instance => _instance ??= new ProductPageViewModel();

        private ProductPageViewModel()
        {
            ShowProgramsCommand = new RelayCommand(x => LoadPrograms());
            ShowGamesCommand = new RelayCommand(x => LoadGames());
            AddProductCommand = new RelayCommand(x => AddProduct());
        }

        private void LoadPrograms()
        {
            DisplayItems.Clear();
            DisplayItems.Add(new ProductItem { Name = "Program Testowy", IconPath = "/Assets/LOGO_U.png" });
            DisplayItems.Add(new ProductItem { Name = "Asystent Księgowości", IconPath = "/Assets/LOGO_U.png" });
            DisplayItems.Add(new ProductItem { Name = "Edytor Kodu", IconPath = "/Assets/LOGO_U.png" });
        }

        private void LoadGames()
        {
            DisplayItems.Clear();
            DisplayItems.Add(new ProductItem { Name = "Minecraft", IconPath = "/Assets/SmallLogo.png" });
            DisplayItems.Add(new ProductItem { Name = "Factorio", IconPath = "/Assets/factorio.png" });
            DisplayItems.Add(new ProductItem { Name = "Rimworld", IconPath = "/Assets/satisfactory.png" });
        }

        private void AddProduct()
        {
            // TODO: Logika dodawania produktu do listy
            // Symulacja pobierania produktu, ma wyglądać
            IsDownloading = true;
            DownloadProgress = 0;

            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += (s, e) =>
            {
                DownloadProgress += 5;
                if (DownloadProgress >= 100)
                {
                    timer.Stop();
                    IsDownloading = false;
                }
            };
            timer.Start();
        }
    }
}
