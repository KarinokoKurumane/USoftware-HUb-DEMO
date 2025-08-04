using USofware_HUb.MVVM.Utility;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using USofware_HUb.MVVM.Models;
using System.Windows;

namespace USofware_HUb.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProductItem> DisplayItems { get; set; } = new();

        public ICommand ShowProgramsCommand { get; }
        public ICommand ShowGamesCommand { get; }
        public ICommand AddProductCommand { get; }

        public ICommand ShowMainCommand { get; }
        public ICommand ShowSettingsPageCommand { get; }
        public ICommand ShowLoginPageCommand { get; }
        public ICommand ExitCommand { get; }


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


        public MainViewModel()
        {
            ShowProgramsCommand = new RelayCommand(LoadPrograms);
            ShowGamesCommand = new RelayCommand(LoadGames);
            AddProductCommand = new RelayCommand(AddProduct);
            ShowMainCommand = new RelayCommand(ShowMainWindow);
            ShowSettingsPageCommand = new RelayCommand(ShowSettingsPage);
            ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
            ExitCommand = new RelayCommand(Application.Current.Shutdown);
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

        private void ShowSettingsPage()
        {
            // TODO: Logika otwierania strony z ustawieniami
        }

        private void ShowLoginPage()
        {
            // TODO: Logika otwierania okna logowania lub wylogowywania
            
            //TaskBarBehaviour.HideTray();
        }

        /// <summary>
        /// Reakcja na kliknięcie przycisku "Otwórz HUB" w Tray'u.
        /// </summary>
        private void ShowMainWindow() => WindowBehaviour.ActivateWindow();

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
