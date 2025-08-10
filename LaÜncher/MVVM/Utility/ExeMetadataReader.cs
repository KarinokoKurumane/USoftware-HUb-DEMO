using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace USoftware_HUb.MVVM.Utility

{
    public class ExeMetadata
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductVersion { get; set; } = string.Empty;
        public string FileDescription { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public BitmapSource? Icon { get; set; }
    }

    public static class ExeMetadataReader
    {
        /// <summary>
        /// Pobiera metadane i ikonę z pliku .exe
        /// </summary>
        public static ExeMetadata? Read(string exePath)
        {
            // Popraw jeśli problemy (z IntelliSense)
            if (!File.Exists(exePath) || !Path.GetExtension(exePath).Equals(".exe", StringComparison.CurrentCultureIgnoreCase))
                return null;

            try
            {
                var info = FileVersionInfo.GetVersionInfo(exePath);
                var icon = Icon.ExtractAssociatedIcon(exePath);

                BitmapSource? iconSource = null;
                if (icon != null)
                {
                    iconSource = Imaging.CreateBitmapSourceFromHIcon(
                        icon.Handle,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
                }

                return new ExeMetadata
                {
                    ProductName = info.ProductName ?? string.Empty,
                    ProductVersion = info.ProductVersion ?? string.Empty,
                    FileDescription = info.FileDescription ?? string.Empty,
                    CompanyName = info.CompanyName ?? string.Empty,
                    Icon = iconSource
                };
            }
            catch (Exception ex)
            {
                // Zastąp logiem po teście
                MessageBox.Show($"Nie udało się odczytać metadanych:\n{ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        /// <summary>
        /// Zapisuje ikonę jako plik PNG
        /// </summary>
        public static bool SaveIcon(BitmapSource icon, string destinationPath)
        {
            try
            {
                using var fileStream = new FileStream(destinationPath, FileMode.Create);
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(icon));
                encoder.Save(fileStream);
                return true;
            }
            catch (Exception ex)
            {
                // Zastąp logiem po teście
                MessageBox.Show($"Nie udało się zapisać ikony:\n{ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}

