using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using USoftwareHUB.Utility;

namespace USoftware_HUb.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Page _currentPage;
        public Page CurrentPage
        {
            get => _currentPage;
            set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); }
        }

        //public ICommand ShowAppsCommand { get; }
        //public ICommand ShowStoreCommand { get; }
        //public ICommand ShowProfileCommand { get; }
        //public ICommand ShowSettingsCommand { get; }
        //public ICommand ShowHelpCommand { get; }

        public ICommand ShowMainCommand { get; }
        public ICommand ShowSettingsPageCommand { get; }
        public ICommand ShowLoginPageCommand { get; }
        public ICommand ExitCommand { get; }

        public MainViewModel()
        {
            //ShowAppsCommand = new RelayCommand(PageManager.Pages.PRODUCT);
            //ShowStoreCommand = new RelayCommand(PageManager.Pages.SHOP);
            //ShowProfileCommand = new RelayCommand(PageManager.Pages.PROFILE);
            //ShowSettingsCommand = new RelayCommand(PageManager.Pages.SETTINGS);
            //ShowHelpCommand = new RelayCommand(PageManager.Pages.HELP);

            _currentPage = PageManager.Get(PageManager.Pages.PRODUCT)!; // domyślna strona

            ShowMainCommand = new RelayCommand(ShowMainWindow);
            ShowSettingsPageCommand = new RelayCommand(ShowSettingsPage);
            ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
            ExitCommand = new RelayCommand(Application.Current.Shutdown);
        }

        private void ShowSettingsPage()
        {
            // TODO: Logika otwierania strony z ustawieniami
        }

        private void ShowLoginPage()
        {
            // TODO: Logika otwierania okna logowania lub wylogowywania
        }

        /// <summary>
        /// Reakcja na kliknięcie przycisku "Otwórz HUB" w Tray'u.
        /// </summary>
        private void ShowMainWindow() => WindowBehaviour.ActivateWindow();

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
