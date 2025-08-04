using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;
using USoftware_HUb.MVVM.ViewModel;

namespace USoftware_HUb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // Ustawienie kontekstu danych dla ikony w zasobniku systemowym
            var trayIcon = (TaskbarIcon)FindResource("TrayIcon");
            trayIcon.DataContext = new MainViewModel();
        }
    }
}