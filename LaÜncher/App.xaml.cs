using System.Windows;
using USofware_HUb.MVVM.Utility;
using USofware_HUb.MVVM.Views;

namespace USofware_HUb
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            WindowManager.RegisterWindow<MainWindow>(WindowManager.Windows.Main);
            WindowManager.RegisterWindow<LoginView>(WindowManager.Windows.Login);

            // Inicjalizacja okna pośredniczącego aplikacji
            WindowManager.ShowSingleWindow(WindowManager.Windows.Login);
        }

        /// <summary>
        /// Reakcja na podwójne kliknięcie ikony w zasobniku systemowym.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskbarIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            WindowBehaviour.ActivateWindow();
        }
    }

}
