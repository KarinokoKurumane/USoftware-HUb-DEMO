using System.Windows;
using USoftware_HUb.MVVM.Views;
using USoftware_HUb.MVVM.Views.Pages;
using USoftwareHUB.Models;
using USoftwareHUB.Services;
using USoftwareHUB.Utility;

namespace USoftware_HUb
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex? _mutex;

        protected override void OnStartup(StartupEventArgs e)
        {
            const string mutexName = "USoftware_HUb_PanCakeEdition";

            _mutex = new Mutex(true, mutexName, out bool isNewInstance);

            if (!isNewInstance)
            {
                MessageBox.Show("The application is already running.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Shutdown();
                return;
            }

            RegisterServices();

            base.OnStartup(e);

            RegisterWindows();
            RegisterPages();

            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            loggerService!.Log("Moving to a new window", LogTagType.INFO);
            WindowManager.ShowSingleWindow(WindowManager.Windows.Login);
        }

        private void RegisterWindows()
        {
            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            
            loggerService!.Log($"Window {WindowManager.Windows.Main} registration has started", LogTagType.INFO);
            WindowManager.RegisterWindow(WindowManager.Windows.Main, () => new MainWindow());

            loggerService!.Log($"Window {WindowManager.Windows.Login} registration has started", LogTagType.INFO);
            WindowManager.RegisterWindow(WindowManager.Windows.Login, () => new LoginView());

            loggerService!.Log($"Window AddProduct registration has started", LogTagType.INFO);
            WindowManager.RegisterWindow("AddProduct", () => new AddProductView());

            loggerService!.Log("Windows registration completed", LogTagType.INFO);
        }

        private void RegisterPages()
        {
            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            loggerService!.Log("Pages registration has started", LogTagType.INFO);

            PageManager.Register<ProductPage>(PageManager.Pages.PRODUCT);
            PageManager.Register<ShopPage>(PageManager.Pages.SHOP);
            
            PageManager.Register<ProfilePage>(PageManager.Pages.PROFILE);
            PageManager.Register<SettingsPage>(PageManager.Pages.SETTINGS);
            PageManager.Register<HelpPage>(PageManager.Pages.HELP);

            loggerService!.Log("Pages registration completed", LogTagType.INFO);
        }

        private void RegisterServices()
        {
            ServiceLocator.RegisterSingleton(new LoggerService());

            ServiceLocator.TryGet<LoggerService>(out var loggerService);
            loggerService!.Log("Services registration completed", LogTagType.INFO);
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
