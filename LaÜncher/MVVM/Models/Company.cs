namespace USoftware_HUb.MVVM.Models
{
    /// <summary>
    /// Klasa reprezentująca firmę.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Nazwa firmy.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Opis firmy (Możliwe, że zbędne).
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Ścieżka do logo firmy.
        /// </summary>
        public string LogoPath { get; set; } = string.Empty;
        /// <summary>
        /// Adres strony internetowej firmy.
        /// </summary>
        public string Website { get; set; } = string.Empty;

    }
}
