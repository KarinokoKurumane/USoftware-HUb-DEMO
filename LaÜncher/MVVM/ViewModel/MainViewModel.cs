using Hardcodet.Wpf.TaskbarNotification;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using USoftware_HUb.MVVM.Models;
using USoftware_HUb.MVVM.Utility;
using USoftware_HUb.MVVM.ViewModel.Pages;
using USoftware_HUb.MVVM.Views.Pages;
using USoftwareHUB.Utility;

namespace USoftware_HUb.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private Window? GetParentWindow() => Window.GetWindow(Application.Current.Windows[0]);

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
        public ICommand? GameCommand { get; }
        public ICommand? ProfileCommand { get; }
        public ICommand? SettingsCommand { get; }
        public ICommand? HelpCommand { get; }
        public ICommand? MinimizeCommand { get; }
        public ICommand? MaximizeCommand { get; }
        public ICommand? CloseCommand { get; }

        /* Tray Command */
        public ICommand? ShowLoginPageCommand { get; }
        public ICommand? ExitCommand { get; }


        private static MainViewModel? _instance;
        public static MainViewModel Instance => _instance ??= new MainViewModel();

        private MainViewModel()
        {
            ShopCommand = new RelayCommand(x => Shop());
            AppCommand = new RelayCommand(x => Applications());
            GameCommand = new RelayCommand(x => Game());
            ProfileCommand = new RelayCommand(x => Profile());
            SettingsCommand = new RelayCommand(x => Settings());
            HelpCommand = new RelayCommand(x => Help());
            MinimizeCommand = new RelayCommand(x => Minimize());
            MaximizeCommand = new RelayCommand(x => Maximize());
            CloseCommand = new RelayCommand(x => Close());

            ShowLoginPageCommand = new RelayCommand(x => ShowLoginPage());
            ExitCommand = new RelayCommand(x => Application.Current.Shutdown());
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

        private void Game()
        {
            // TODO: Implementacja logiki gier
            SetPage(PageManager.Get(PageManager.Pages.PGAME)!);
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
            WindowBehaviour.ActivateWindow();
        }
    }
}
