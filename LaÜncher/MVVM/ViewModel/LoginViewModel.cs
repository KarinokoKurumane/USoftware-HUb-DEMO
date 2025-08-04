using USofware_HUb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using USofware_HUb.MVVM.Utility;

namespace USofware_HUb.MVVM.ViewModel
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand OfflineCommand { get; }
        public ICommand QuitCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);
            OfflineCommand = new RelayCommand(Offline);
            QuitCommand = new RelayCommand(Shutdown);
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

        private void ShowMainWindow() => WindowManager.ShowSingleWindow(WindowManager.Windows.Main, true);

        private void Shutdown() => WindowManager.CloseWindow(WindowManager.Windows.Login, true);

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
