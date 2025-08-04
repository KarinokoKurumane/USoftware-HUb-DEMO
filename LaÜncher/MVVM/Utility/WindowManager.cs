using System.Windows;

namespace USofware_HUb.MVVM.Utility
{
    public static class WindowManager
    {
        public struct Windows
        {
            public const string Main = "Main";
            public const string Login = "Login";
        }

        /// <summary>
        /// Zawiera zarejestrowane okna
        /// </summary>
        private static readonly Dictionary<string, Type> _windowRegistry = [];

        /// <summary>
        /// Rejestruje typa okna
        /// </summary>
        /// <typeparam name="T">Okno, z którego pozyskany zostanie typ</typeparam>
        /// <param name="key">Klucz pod jakim zostanie zapisany typ</param>
        public static void RegisterWindow<T>(string key) where T : Window, new() => _windowRegistry[key] = typeof(T);


        /// <summary>
        /// Pokazuje okno zamykając pozostałe (jeśli wymagane)
        /// </summary>
        /// <param name="windowKey">Klucz okna jakie ma zostać otwarte</param>
        /// <param name="animations">Czy ma być animacja zamknięcia zamykanego okna</param>
        public static void ShowSingleWindow(string windowKey, bool animations = false)
        {
            if (_windowRegistry.TryGetValue(windowKey, out var windowType))
            {
                var window = (Window)Activator.CreateInstance(windowType)!;
                var currentWindow = Application.Current.MainWindow;

                switch (currentWindow)
                {
                    case null:
                    case var w when w.GetType() == window.GetType():
                        break;
                    case var _ when animations:
                        Animations.CloseWithAnimation(currentWindow);
                        break;
                    default:
                        currentWindow.Close();
                        break;
                }

                Application.Current.MainWindow = window;
                window.Show();
            }
        }

        /// <summary>
        /// Wyświetla okno w obecności innych okien
        /// </summary>
        /// <param name="windowKey"></param>
        public static void ShowMultiWindow(string windowKey)
        {
            if (_windowRegistry.TryGetValue(windowKey, out var windowType))
            {
                var window = (Window)Activator.CreateInstance(windowType)!;
                window.Show();
            }
        }

        /// <summary>
        /// Zamyka okno
        /// </summary>
        /// <param name="windowKey">Klucz zamykanego okna</param>
        /// <param name="animations">Czy ma być animacja zamknięcia zamykanego okna</param>
        public static void CloseWindow(string windowKey, bool animations = false)
        {
            if (_windowRegistry.TryGetValue(windowKey, out var windowType))
            {
                foreach (Window openWindow in Application.Current.Windows)
                {
                    if (openWindow.GetType() == windowType)
                    {
                        if (animations)
                            Animations.CloseWithAnimation(openWindow);
                        else
                            openWindow.Close();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Pozyskuje klucz okna
        /// </summary>
        /// <param name="targetWindow">Okno, z którego ma zostać pozykany klucz</param>
        /// <returns>Klucz okna, jeśli okno zostało zarejestrowane</returns>
        public static string? GetWindowKey(Window targetWindow)
        {
            var targetType = targetWindow.GetType();
            return _windowRegistry.FirstOrDefault(pair => pair.Value == targetType).Key;
        }

        /// <summary>
        /// Sprawdza, czy okno jest zarejestrowane
        /// </summary>
        /// <param name="window">Okno, które chce się sprawdzić</param>
        /// <returns>True jest jest zarejestrowane</returns>
        public static bool IsRegistered(Window window) => GetWindowKey(window) != null;
    }
}
