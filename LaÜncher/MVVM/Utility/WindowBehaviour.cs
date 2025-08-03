using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;

namespace USofware_HUb.MVVM.Utility
{
    internal static class WindowBehaviour
    {
        /// <summary>
        /// Aktualizuje stan okna głównego aplikacji, przywracając je do normalnego stanu.
        /// </summary>
        /// <returns>true jeśli się udało</returns>
        internal static bool ActivateWindow()
        {
            // Możliwe, że Application.Current.Windows[0] będzie lepsze
            var mainWindow = GetParentWindow();
            if (mainWindow != null)
            {
                mainWindow.Show();
                mainWindow.WindowState = WindowState.Normal;
                mainWindow.Activate();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Minimalizuje okno do zasobnika systemowego (tray).
        /// </summary>
        /// <returns></returns>
        internal static bool MinimizeToTray()
        {
            // Możliwe, że Application.Current.Windows[0] będzie lepsze
            var mainWindow = GetParentWindow();
            if (mainWindow != null)
            {
                mainWindow.Hide();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Pozyskuje okno nadrzędne dla aktualnej aplikacji.
        /// </summary>
        /// <returns></returns>
        internal static Window? GetParentWindow()
        {
            // Możliwe, że Application.Current.Windows[0] będzie lepsze
            return Application.Current.Windows.OfType<Window>().FirstOrDefault();
        }
    }
}
