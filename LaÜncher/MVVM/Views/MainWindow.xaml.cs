using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;
using USoftware_HUb.MVVM.ViewModel;
using USoftwareHUB.Models;
using USoftwareHUB.Services;

namespace USoftware_HUb.MVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            loggerService!.Log("Initialize Component", LogTagType.INFO, "MainWindow .ctor");
            
            InitializeComponent();

            Loaded += (_, _) => DataContext = MainViewModel.Instance;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // Ustawienie kontekstu danych dla ikony w zasobniku systemowym
            var trayIcon = (TaskbarIcon)FindResource("TrayIcon");
            trayIcon.DataContext = MainViewModel.Instance;
        }
    }
}