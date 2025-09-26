using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using USoftware_HUb.MVVM.Utility;
using USoftwareHUB.Services;
using USoftwareHUB.Models;
using USoftwareHUB.Utility;
using System.Windows.Controls;

namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    class ProductPageViewModel : ObservableObject
    {
        public ObservableCollection<ProductItem> DisplayItems { get; set; } = new();

        private UserControl _currentControl = UserControlManager.Get(UserControlManager.UserControls.Details)!;
        public UserControl CurrentControl
        {
            get => _currentControl;
            set
            {
                _currentControl = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenSettingsCommand { get; }
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

        private string _executionPath = string.Empty;
        public string ExecutionPath
        {
            get => _executionPath;
            set { _executionPath = value; OnPropertyChanged(); }
        }

        private ProductItem? _selectedProduct;
        public ProductItem? SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();

                // Aktualizacja danych do kontrolki ProductSheet
                // Wymagana aktualizacja o kojejne dane (wymagania, tagi)
                if (value != null)
                {
                    ProductName = value.Name;
                    ProductDesryption = value.Description;
                    ExecutionPath = value.ExecutionPath;
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
            Messenger.ProductAdded += OnProductAdded;

            LoadData();

            OpenSettingsCommand = new RelayCommand(x => OpenSettings());
            RunAppCommand = new RelayCommand(x => RunApp());
            RunAsGroupCommand = new RelayCommand(x => RunAsGroup());
            AddToGroupCommand = new RelayCommand(x => AddToGroup());
            RemoveFromGroupCommand = new RelayCommand(x => RemoveFromGroup());

            ShowProgramsCommand = new RelayCommand(x => ShowPrograms());
            ShowGamesCommand = new RelayCommand(x => ShowGames());
            AddProductCommand = new RelayCommand(x => AddProduct());
        }

        private void OnProductAdded(string type)
        {
            LoadData();
            if (type == "app")
                ShowPrograms();
            else
                ShowGames();
        }

        private void OpenSettings()
        {
            CurrentControl = UserControlManager.Get(UserControlManager.UserControls.Settings)!;
        }

        private void RunApp()
        {
            if (_selectedProduct is null)
            {
                MessageBox.Show("Nie wybrano produktu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string path = _selectedProduct.ExecutionPath;

            if (!File.Exists(path))
            {
                MessageBox.Show($"Plik nie istnieje:\n{path}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Uruchomienie aplikacji, jeśli to możliwe wyizoluj to
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true // pozwala na uruchamianie skrótów, plików .exe, itd.
                });

                // Ukrycie okna i powiadomienie
                WindowBehaviour.HideWindow();
                TaskBarBehaviour.ShowBalloonTip($"Aplikacja {_selectedProduct.Name} uruchomiona", "HÜB został zminimalizowany do zasobnika.");

                // Logowanie, nowe, niby lepsze, w razie czego zmień na stary styl
                if (ServiceLocator.TryGet<LoggerService>(out var logger))
                {
                    logger!.Log($"Uruchomiono produkt: {_selectedProduct.Name}", LogTagType.SUCCESS);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie udało się uruchomić aplikacji:\n{ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);

                if (ServiceLocator.TryGet<LoggerService>(out var logger))
                {
                    logger!.Log(ex);
                }
            }
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
