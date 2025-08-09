using System.Windows.Input;
using USoftwareHUB.Utility;

namespace USoftware_HUb.MVVM.ViewModel
{
    internal class LoginViewModel : ObservableObject
    {
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand OfflineCommand { get; }
        public ICommand QuitCommand { get; }

        private static LoginViewModel? _instance;
        public static LoginViewModel Instance => _instance ??= new LoginViewModel();
        private LoginViewModel()
        {
            LoginCommand = new RelayCommand(x => Login());
            RegisterCommand = new RelayCommand(x => Register());
            OfflineCommand = new RelayCommand(x => Offline());
            QuitCommand = new RelayCommand(x => Shutdown());
        }

        private void Login()
        {
            // TODO: Pokazanie okna logowania (dialog)
        }

        private void Register()
        {
            // TODO: Pokazanie okna rejestracji
        }

        private void Offline() => ShowMainWindow();

        private void ShowMainWindow() => WindowManager.ShowSingleWindow(WindowManager.Windows.Main, false);

        private void Shutdown() => WindowManager.CloseWindow(WindowManager.Windows.Login, true);
    }
}
