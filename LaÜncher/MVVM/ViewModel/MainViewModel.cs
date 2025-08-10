using System.Data.Common;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using USoftware_HUb.MVVM.Views;
using USoftwareHUB.Models;
using USoftwareHUB.Services;
using USoftwareHUB.Utility;

namespace USoftware_HUb.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private Window? GetParentWindow() => Window.GetWindow(Application.Current.Windows[0]);

        private WindowState currentState = WindowState.Normal;

        private UserControl _currentPage = PageManager.Get(PageManager.Pages.PRODUCT)!;
        public UserControl CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        /* Titlebar Command */
        public ICommand? ShopCommand { get; }
        public ICommand? AppCommand { get; }
        public ICommand? ProfileCommand { get; }
        public ICommand? SettingsCommand { get; }
        public ICommand? HelpCommand { get; }
        public ICommand? MinimizeCommand { get; }
        public ICommand? MaximizeCommand { get; }
        public ICommand? CloseCommand { get; }

        /* Tray Command */
        public ICommand? ShowLoginPageCommand { get; }
        public ICommand? ExitCommand { get; }

        /* Statusbar Command */
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


        private static MainViewModel? _instance;
        public static MainViewModel Instance => _instance ??= new MainViewModel();

        private MainViewModel()
        {
            ShopCommand = new RelayCommand(x => Shop());
            AppCommand = new RelayCommand(x => Applications());
            
            ProfileCommand = new RelayCommand(x => Profile());
            SettingsCommand = new RelayCommand(x => Settings());
            HelpCommand = new RelayCommand(x => Help());
            MinimizeCommand = new RelayCommand(x => Minimize());
            MaximizeCommand = new RelayCommand(x => Maximize());
            CloseCommand = new RelayCommand(x => Close());
            AddProductCommand = new RelayCommand(AddProduct);

            ShowLoginPageCommand = new RelayCommand(x => ShowLoginPage());
            ExitCommand = new RelayCommand(x => Application.Current.Shutdown());
        }

        private void AddProduct(object parameter)
        {
            if (parameter is not string productType)
                return;

            WindowManager.ShowMultiWindow(WindowManager.Windows.AddProduct, productType);
        }

        private void Shop()
        {
            // TODO: Implementacja logiki sklepu
            SetPage(PageManager.Get(PageManager.Pages.SHOP)!);
        }

        private void Applications()
        {
            // TODO: Implementacja logiki aplikacji
            SetPage(PageManager.Get(PageManager.Pages.PRODUCT)!);
        }

        private void Profile()
        {
            // TODO: Implementacja logiki profilu
            SetPage(PageManager.Get(PageManager.Pages.PROFILE)!);
        }

        private void Settings()
        {
            // TODO: Implementacja logiki ustawień
            SetPage(PageManager.Get(PageManager.Pages.SETTINGS)!);
        }

        private void Help()
        {
            // TODO: Implementacja logiki pomocy
            SetPage(PageManager.Get(PageManager.Pages.HELP)!);
        }

        private void ShowLoginPage()
        {
            // TODO: Logika otwierania okna logowania lub wylogowywania
        }

        private void Minimize()
        {
            GetParentWindow()!.WindowState = WindowState.Minimized;
        }

        private void Maximize()
        {
            var win = GetParentWindow();
            if (win == null) return;

            win.WindowState = win.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            currentState = win.WindowState;
            //(sender as Button)!.Content = win.WindowState == WindowState.Maximized ? "❐" : "⬜";
        }

        private void Close()
        {
            // TODO: zamknij okno z animacją lub minimalizuj do zasobnika systemowego w zależności od ustawień użytkownika
            var _userSettings = true; // true - minimalizuj do zasobnika, false - zamknij okno
            if (_userSettings)
            {
                WindowBehaviour.HideWindow();
            }
            else
            {
                Animations.CloseWithAnimation(GetParentWindow()!);
            }
        }

        /// <summary>
        /// Ustawia konkretną stronę jako wyświetlaną oraz aktywuje okno jeśli wymagane
        /// </summary>
        /// <param name="page">Strona do wyświetlenia</param>
        private void SetPage(UserControl page)
        {
            CurrentPage = page;

            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            loggerService!.Log($"Change page: {PageManager.GetKey(page)}", LogTagType.INFO);

            WindowBehaviour.ActivateWindow();
        }
    }
}
