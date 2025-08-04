using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using USoftwareHUB.Utility;

namespace USoftware_HUb.MVVM.ViewModel
{
    internal class TitleBarViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand LoginCommand { get; }
        public ICommand HelpCommand { get; }
        public ICommand MinimizeCommand { get; }
        public ICommand MaximizeCommand { get; }
        public ICommand CloseCommand { get; }

        private Window? GetParentWindow() => Window.GetWindow(Application.Current.Windows[0]);

        public TitleBarViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            HelpCommand = new RelayCommand(Help);
            MinimizeCommand = new RelayCommand(Minimize);
            MaximizeCommand = new RelayCommand(Maximize);
            CloseCommand = new RelayCommand(Close);
        }

        private void Login()
        {
            // TODO: Implementacja logiki logowania
        }

        private void Help()
        {
            // TODO: Implementacja logiki pomocy
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

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
