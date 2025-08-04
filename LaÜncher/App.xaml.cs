using System.IO;
using System.Reflection;
using System.Windows;
using USoftware_HUb.MVVM.ViewModel.Pages;
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
            DllPath();
            RegisterWindows();
            RegisterPages();

            WindowManager.ShowSingleWindow(WindowManager.Windows.Login);
        }

        private void DllPath()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string assemblyName = new AssemblyName(args.Name).Name + ".dll";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", assemblyName);

                if (File.Exists(path))
                {
                    return Assembly.LoadFrom(path);
                }

                return null;
            };
        }

        private void RegisterWindows()
        {
            WindowManager.RegisterWindow<MainWindow>(WindowManager.Windows.Main);
            WindowManager.RegisterWindow<LoginView>(WindowManager.Windows.Login);
        }

        private void RegisterPages()
        {
            PageManager.Register<ProductPage>(PageManager.Pages.PRODUCT);
            PageManager.Register<ShopPage>(PageManager.Pages.SHOP);
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
