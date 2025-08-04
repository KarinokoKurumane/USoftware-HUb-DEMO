namespace USoftware_HUb.MVVM.Models
{
    public class ProductItem
    {
        /// <summary>
        /// Unikalne ID produktu.
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// Nazwa produktu.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Opis produktu.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Lista producentów produktu (Możliwe, że tylko 1, no ale czasami bywa więcej).
        /// </summary>
        public List<Company> Producers { get; set; } = [];
        /// <summary>
        /// Wydawcy produktu (Możliwe, że wymagane będzie zmienie na zwykłą zmienną Company).
        /// </summary>
        public List<Company> Publishers { get; set; } = [];
        /// <summary>
        /// Ścieżka do ikony produktu.
        /// </summary>
        public string IconPath { get; set; } = string.Empty;
        /// <summary>
        /// Ścieżka do grafiki produktu (Może być używana jako tło lub obrazek w aplikacji).
        /// </summary>
        public string BannerPath { get; set; } = string.Empty;

    }
}
