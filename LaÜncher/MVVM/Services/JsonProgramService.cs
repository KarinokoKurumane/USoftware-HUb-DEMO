using USofware_HUb.MVVM.Models;
using System.IO;
using System.Text.Json;

namespace USofware_HUb.MVVM.Services
{
    internal class JsonProgramService
    {
        public static ProgramData? ReadJsonSection(string path, string section)
        {
            if (!File.Exists(path)) return null;

            try
            {
                string json = File.ReadAllText(path);
                var allData = JsonSerializer.Deserialize<Dictionary<string, ProgramData>>(json);
                return allData != null && allData.ContainsKey(section) ? allData[section] : null;
            }
            catch
            {
                return null;
            }
        }

        public static bool WriteJsonSection(string path, string section, ProgramData sectionData)
        {
            if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(section) || sectionData is null)
                return false;

            Dictionary<string, ProgramData> allData = new();

            try
            {
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    allData = JsonSerializer.Deserialize<Dictionary<string, ProgramData>>(json) ?? new();
                }

                allData[section] = sectionData;

                // Wymuszenie zapisu nawet gdy plik jest otwarty w innym procesie (jeśli możliwe)
                using var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                using var writer = new StreamWriter(fs);
                string updatedJson = JsonSerializer.Serialize(allData, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                writer.Write(updatedJson);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
