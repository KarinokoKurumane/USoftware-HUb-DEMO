using System.Windows;
using USoftware_HUb.MVVM.Views;
using USoftware_HUb.MVVM.Views.Pages;
using USoftwareHUB.Utility;

namespace USoftware_HUb
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            RegisterWindows();
            RegisterPages();

            WindowManager.ShowSingleWindow(WindowManager.Windows.Login);
        }

        private void RegisterWindows()
        {
            WindowManager.RegisterWindow(WindowManager.Windows.Main, () => new MainWindow());
            WindowManager.RegisterWindow(WindowManager.Windows.Login, () => new LoginView());
        }

        private void RegisterPages()
        {
            PageManager.Register<ProductPage>(PageManager.Pages.PRODUCT);
            PageManager.Register<ShopPage>(PageManager.Pages.SHOP);
            PageManager.Register<GamePage>(PageManager.Pages.PGAME);
            PageManager.Register<ProfilePage>(PageManager.Pages.PROFILE);
            PageManager.Register<SettingsPage>(PageManager.Pages.SETTINGS);
            PageManager.Register<HelpPage>(PageManager.Pages.HELP);
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
