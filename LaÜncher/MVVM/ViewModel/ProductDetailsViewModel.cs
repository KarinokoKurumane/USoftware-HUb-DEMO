using System.Windows;
using System.Windows.Input;
using USoftwareHUB.Utility;
using USoftware_HUb.MVVM.Utility;

namespace USoftware_HUb.MVVM.ViewModel
{
    public class ProductDetailsViewModel: ObservableObject
    {
        public ICommand RunAppCommand { get; }

        public ICommand RunAsGroupCommand { get; }

        public ICommand AddToGroupCommand { get; }

        public ICommand RemoveFromGroupCommand { get; }

        private static ProductDetailsViewModel? _instance;
        public static ProductDetailsViewModel Instance => _instance ??= new ProductDetailsViewModel();

        private ProductDetailsViewModel()
        {
            // TODO: Inicjalizacja szczegółów produktu
            RunAppCommand = new RelayCommand(x => RunApp());
            RunAsGroupCommand = new RelayCommand(x => RunAsGroup());
            AddToGroupCommand = new RelayCommand(x => AddToGroup());
            RemoveFromGroupCommand = new RelayCommand(x => RemoveFromGroup());
        }


        private void RunApp()
        {
            // TODO: Logika uruchamiania aplikacji

            WindowBehaviour.HideWindow();
            TaskBarBehaviour.ShowBalloonTip("Aplikacja uruchomiona", "HÜB został zminimalizowany do zasobnika.");
        }

        private void RunAsGroup()
        {
            // TODO: Logika uruchamiania aplikacji jako grupa

            WindowBehaviour.HideWindow();
            TaskBarBehaviour.ShowBalloonTip("Grupa aplikacji uruchomiona", "HÜB został zminimalizowany do zasobnika.");
        }

        private void AddToGroup()
        {
            // TODO: Logika dodawania aplikacji do grupy
            MessageBox.Show("Aplikacja została dodana do grupy!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RemoveFromGroup()
        {
            // TODO: Logika usuwania aplikacji z grupy
            MessageBox.Show("Aplikacja została usunięta z grupy!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
