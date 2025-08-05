using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace USoftware_HUb.MVVM.Utility
{
    public static class LanguageManager
    {
        private static readonly string _languageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Languages");

        public static Dictionary<string, string> Translations { get; private set; } = new();
        public static string CurrentLanguage { get; private set; } = "pl";

        public static void LoadLanguage(string languageCode)
        {
            var filePath = Path.Combine(_languageFolder, $"{languageCode}.json");

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"Error - no existing file", $"Load language error!", MessageBoxButton.OK, MessageBoxImage.Error);
                Translations = [];
                return;
            }

            try
            {
                var json = File.ReadAllText(filePath);
                Translations = JsonConvert.DeserializeObject<Dictionary<string, string>>(json) ?? [];
                CurrentLanguage = languageCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}", $"Load language error!", MessageBoxButton.OK, MessageBoxImage.Error);
                Translations = [];
            }
        }

        public static string Translate(string key)
        {
            return Translations.TryGetValue(key, out var value) ? value : $"[{key}]";
        }

        public static List<string> GetAvailableLanguages()
        {
            if (!Directory.Exists(_languageFolder))
                return [];

            var files = Directory.GetFiles(_languageFolder, "*.json");
            var languages = new List<string>();

            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                languages.Add(name);
            }

            return languages;
        }

    }
}
