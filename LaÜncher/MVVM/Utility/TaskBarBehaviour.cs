using Hardcodet.Wpf.TaskbarNotification;
using System.Drawing;
using System.Windows;
using USoftware_HUb.MVVM.Models;

namespace USoftware_HUb.MVVM.Utility
{
    internal static class TaskBarBehaviour
    {
        internal static bool ShowBalloonTip(string title, string message)
        {
            var _trayIcon = (TaskbarIcon)Application.Current.FindResource("TrayIcon");
            Icon _icon = new(Application.GetResourceStream(new Uri("pack://application:,,,/Assets/LOGO_U.ico")).Stream);
            if (_trayIcon != null)
            {
                _trayIcon.ShowBalloonTip(title, message, _icon, true);
                return true;
            }
            return false;
        }
        
        internal static bool ShowBalloonTip(ProductItem product)
        {
            var _trayIcon = (TaskbarIcon)Application.Current.FindResource("TrayIcon");
            Icon _icon = new(product.IconPath);
            if (_trayIcon != null)
            {
                _trayIcon.ShowBalloonTip($"Aplikacja {product.Name} uruchomiona", "HÜB zostaje schowany, aby Ci nie przeszkadzać.", _icon, true);
                return true;
            }
            return false;
        }

        internal static bool HideTray()
        {
            if (Application.Current.Resources["TrayIcon"] is TaskbarIcon trayIcon)
            {
                trayIcon.Visibility = Visibility.Collapsed;
                return true;
            }
            return false;
        }

        internal static bool ShowTray()
        {
            if (Application.Current.Resources["TrayIcon"] is TaskbarIcon trayIcon)
            {
                trayIcon.Visibility = Visibility.Visible;
                return true;
            }
            return false;
        }
    }
}
