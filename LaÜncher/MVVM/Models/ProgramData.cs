namespace USofware_HUb.MVVM.Models
{
    internal class ProgramData
    {
        /// <summary>
        /// Zawiera nazwę aplikacji
        /// </summary>
        public string programName = "Program Testowy";
        /// <summary>
        /// Zawiera opis aplikacji
        /// </summary>
        public string programDesc = "Jest to aplikacja testowa, która ma na celu zaprezentować funkcjonalność LaÜnchera firmy ÜSoftware";
        /// <summary>
        /// Zawiera wersję aplikacji
        /// </summary>
        public string programVersion = "1.0.0.0";

        /// <summary>
        /// Zawiera ścieżkę do folderu aplikacji
        /// </summary>
        public string programDataPath = string.Empty;
        /// <summary>
        /// Zawiera ścieżkę do folderu z ikoną lub obrazkiem PNG aplikacji
        /// </summary>
        public string programImgPath = string.Empty;

        /// <summary>
        /// Czy aplikacja została zainstalowana (jeśli nie, jest do pobrania, jeśli jest, jest do uruchomienia) 
        /// </summary>
        public bool isInstalled = false;
        /// <summary>
        /// Czy dana aplikacja ma własny launcher (jeśli ma, można go usunąć podczas instalacji, aktualizacja będzie stała po stronie LaÜnchera)
        /// </summary>
        public bool haveUpdater = false;
    }
}
