using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using USoftware_HUb.MVVM.Utility;
using USoftwareHUB.Services;
using USoftwareHUB.Models;
using USoftwareHUB.Utility;

namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    class ProductPageViewModel : ObservableObject
    {
        public ObservableCollection<ProductItem> DisplayItems { get; set; } = new();

        public ICommand RunAppCommand { get; }
        public ICommand RunAsGroupCommand { get; }
        public ICommand AddToGroupCommand { get; }
        public ICommand RemoveFromGroupCommand { get; }

        public ICommand ShowProgramsCommand { get; }
        public ICommand ShowGamesCommand { get; }
        public ICommand AddProductCommand { get; }

        private string _productName = string.Empty;
        public string ProductName
        {
            get => _productName;
            set { _productName = value; OnPropertyChanged(); }
        }

        private string _productDescription = string.Empty;
        public string ProductDesryption
        {
            get => _productDescription;
            set { _productDescription = value; OnPropertyChanged(); }
        }

        private string _bannerPath = string.Empty;
        public string BannerPath
        {
            get => _bannerPath;
            set { _bannerPath = value; OnPropertyChanged(); }
        }

        private string _logoPath = string.Empty;
        public string LogoPath
        {
            get => _logoPath;
            set { _logoPath = value; OnPropertyChanged(); }
        }

        private bool _isDownloading;
        public bool IsDownloading
        {
            get => _isDownloading;
            set { _isDownloading = value; OnPropertyChanged(); }
        }

        private double _downloadProgress;
        public double DownloadProgress
        {
            get => _downloadProgress;
            set { _downloadProgress = value; OnPropertyChanged(); }
        }

        private ProductItem? _selectedProduct;
        public ProductItem? SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();

                // Aktualizacja danych do kontrolki ProductDetails
                // Wymagana aktualizacja o kojejne dane (wymagania, tagi)
                if (value != null)
                {
                    ProductName = value.Name;
                    ProductDesryption = value.Description;
                    BannerPath = value.BannerPath;
                    LogoPath = value.IconPath;
                }
            }
        }

        private readonly List<ProductItem> _applications = [];
        private readonly List<ProductItem> _games = [];

        private static ProductPageViewModel? _instance;
        public static ProductPageViewModel Instance => _instance ??= new ProductPageViewModel();

        private ProductPageViewModel()
        {
            LoadData();

            RunAppCommand = new RelayCommand(x => RunApp());
            RunAsGroupCommand = new RelayCommand(x => RunAsGroup());
            AddToGroupCommand = new RelayCommand(x => AddToGroup());
            RemoveFromGroupCommand = new RelayCommand(x => RemoveFromGroup());

            ShowProgramsCommand = new RelayCommand(x => ShowPrograms());
            ShowGamesCommand = new RelayCommand(x => ShowGames());
            AddProductCommand = new RelayCommand(x => AddProduct());
        }

        private void RunApp()
        {
            // TODO: Logika uruchamiania aplikacji
            if (_selectedProduct is null)
                return;

            WindowBehaviour.HideWindow();
            TaskBarBehaviour.ShowBalloonTip($"Aplikacja {_selectedProduct.Name} uruchomiona", "HÜB został zminimalizowany do zasobnika.");
        }

        private void RunAsGroup()
        {
            // TODO: Logika uruchamiania aplikacji jako grupa
            if (_selectedProduct is null)
                return;

            WindowBehaviour.HideWindow();
            TaskBarBehaviour.ShowBalloonTip($"Grupa aplikacji uruchomiona", "HÜB został zminimalizowany do zasobnika.");
        }

        private void AddToGroup()
        {
            // TODO: Logika dodawania aplikacji do grupy
            if (_selectedProduct is null)
                return;

            MessageBox.Show("Aplikacja została dodana do grupy!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RemoveFromGroup()
        {
            // TODO: Logika usuwania aplikacji z grupy
            if (_selectedProduct is null)
                return;

            MessageBox.Show("Aplikacja została usunięta z grupy!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowPrograms()
        {
            DisplayItems.Clear();
            foreach (var item in _applications)
                DisplayItems.Add(item);

            if (DisplayItems.Count > 0)
                SelectedProduct = DisplayItems[0];
        }

        private void ShowGames()
        {
            DisplayItems.Clear();
            foreach (var item in _games)
                DisplayItems.Add(item);

            if (DisplayItems.Count > 0)
                SelectedProduct = DisplayItems[0];
        }

        private void LoadData()
        {
            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            loggerService!.Log("Start loading products", LogTagType.INFO);
            var _base = Path.Combine(Directory.GetCurrentDirectory(), "ProductsData");

            _games.Clear();
            if (JsonProgramService.Read<List<ProductItem>>(Path.Combine(_base, "games.json"), out var __games))
            {
                foreach (var game in __games)
                    _games.Add(game);
                loggerService!.Log($"Complete loading {_games.Count} games", LogTagType.INFO);
            }
            else
            {
                loggerService!.Log($"No games to load", LogTagType.INFO);
            }

                _applications.Clear();
            if (JsonProgramService.Read<List<ProductItem>>(Path.Combine(_base, "apps.json"), out var _apps))
            {
                foreach (var app in _apps)
                    _applications.Add(app);
                loggerService!.Log($"Complete loading {_applications.Count} applications", LogTagType.INFO);
            }
            else
            {
                loggerService!.Log($"No applications to load", LogTagType.INFO);
            }
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
