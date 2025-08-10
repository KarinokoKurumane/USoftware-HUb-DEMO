using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;
using USoftware_HUb.MVVM.Utility;
using USoftwareHUB.Models;
using USoftwareHUB.Services;
using USoftwareHUB.Utility;

namespace USoftware_HUb.MVVM.ViewModel
{
    public class AddProductViewModel : ObservableObject
    {
        public string ProductType { get; }
        public string ProductTypeLabel => $"Dodajesz nowy produkt typu {(ProductType == "game" ? "🎮 gra" : "📱 aplikacja")}";

        private string _productName = string.Empty;
        public string ProductName
        {
            get => _productName;
            set { _productName = value; OnPropertyChanged(nameof(ProductName)); }
        }

        private string _productDescription = string.Empty;
        public string ProductDescription
        {
            get => _productDescription;
            set { _productDescription = value; OnPropertyChanged(nameof(ProductDescription)); }
        }

        private string _executablePath = string.Empty;
        public string ExecutablePath
        {
            get => _executablePath;
            set { _executablePath = value; OnPropertyChanged(nameof(ExecutablePath)); }
        }

        private string _iconPath = string.Empty;
        public string IconPath
        {
            get => _iconPath;
            set { _iconPath = value; OnPropertyChanged(nameof(IconPath)); }
        }

        private string _bannerPath = string.Empty;
        public string BannerPath
        {
            get => _bannerPath;
            set { _bannerPath = value; OnPropertyChanged(nameof(BannerPath)); }
        }

        // Ścieżka do tymczasowo zapisanej ikony
        private string? _tempIconPath;

        public ICommand BrowseExecutableCommand { get; }
        public ICommand BrowseIconCommand { get; }
        public ICommand BrowseBannerCommand { get; }
        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public event Action? RequestClose;

        public AddProductViewModel(string productType)
        {
            ProductType = productType;

            BrowseExecutableCommand = new RelayCommand(_ => BrowseForExecutable());
            BrowseIconCommand = new RelayCommand(_ => BrowseForIcon());
            BrowseBannerCommand = new RelayCommand(_ => BrowseForBanner());
            ConfirmCommand = new RelayCommand(_ => Confirm());
            CancelCommand = new RelayCommand(_ => RequestClose?.Invoke());
        }

        private void BrowseForExecutable()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Pliki wykonywalne (*.exe)|*.exe",
                Title = "Wybierz plik wykonywalny"
            };

            if (dialog.ShowDialog() == true)
            {
                ExecutablePath = dialog.FileName;

                var metadata = ExeMetadataReader.Read(ExecutablePath);
                if (metadata != null)
                {
                    // Fallback do nazwy pliku, jeśli metadane nie zawierają nazwy
                    var fallbackName = Path.GetFileNameWithoutExtension(ExecutablePath);

                    if (string.IsNullOrWhiteSpace(ProductName))
                        ProductName = string.IsNullOrWhiteSpace(metadata.ProductName) ? fallbackName : metadata.ProductName;

                    if (string.IsNullOrWhiteSpace(ProductDescription))
                        ProductDescription = metadata.FileDescription;

                    // Zapisz ikonę tymczasowo
                    if (metadata.Icon != null)
                    {
                        var tempDir = Path.Combine(Directory.GetCurrentDirectory(), "TempIcons");
                        Directory.CreateDirectory(tempDir);

                        var tempIconFile = Path.Combine(tempDir, $"{ProductName}_temp.png");

                        if (ExeMetadataReader.SaveIcon(metadata.Icon, tempIconFile))
                        {
                            _tempIconPath = tempIconFile;
                            IconPath = tempIconFile; // dla podglądu w UI
                        }
                    }
                }
            }
        }

        private void BrowseForIcon()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Obrazy (*.png;*.jpg)|*.png;*.jpg",
                Title = "Wybierz ikonę produktu"
            };

            if (dialog.ShowDialog() == true)
            {
                IconPath = dialog.FileName;
                _tempIconPath = null; // nadpisano ręcznie, więc nie przenosimy później
            }
        }

        private void BrowseForBanner()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Obrazy (*.png;*.jpg)|*.png;*.jpg",
                Title = "Wybierz grafikę bannerową"
            };

            if (dialog.ShowDialog() == true)
            {
                BannerPath = dialog.FileName;
            }
        }

        private void Confirm()
        {
            if (string.IsNullOrWhiteSpace(ProductName))
            {
                MessageBox.Show("Musisz podać nazwę produktu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ExecutablePath))
            {
                MessageBox.Show("Musisz wybrać plik wykonywalny.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Przenosi ikonę z folderu tymczasowego do docelowego
            if (!string.IsNullOrWhiteSpace(_tempIconPath) && File.Exists(_tempIconPath))
            {
                var finalIconDir = Path.Combine(Directory.GetCurrentDirectory(), "ProductsData", ProductName, "Icons");
                Directory.CreateDirectory(finalIconDir);

                var finalIconPath = Path.Combine(finalIconDir, $"{ProductName}.png");

                try
                {
                    File.Copy(_tempIconPath, finalIconPath, overwrite: true);
                    IconPath = finalIconPath;
                    File.Delete(_tempIconPath); // usuwa tymczasową ikonę
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Nie udało się przenieść ikony:\n{ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            SaveNewProduct();
            RequestClose?.Invoke();
        }

        private void SaveNewProduct()
        {
            var newProduct = new ProductItem
            {
                Name = ProductName,
                Description = ProductDescription,
                ExecutionPath = ExecutablePath,
                IconPath = IconPath,
                BannerPath = BannerPath
            };

            var isSave = JsonProgramService.AppendRecord(Path.Combine(Directory.GetCurrentDirectory(), "ProductsData", $"{ProductType}s.json"), newProduct);

            ServiceLocator.TryGet<LoggerService>(out var loggerService);

            if (isSave)
            {
                loggerService!.Log($"Successfully save record", LogTagType.SUCCESS);
                Messenger.SendProductAdded(ProductType);
            }
            else
                loggerService!.Log($"Unsuccessfully save record", LogTagType.ERROR);
        }
    }
}