namespace USoftware_HUb.MVVM.Models
{
    class ProductGroup
    {
        /// <summary>
        /// Id grupy produktów.
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// Nazwa grupy produktów.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Opis grupy produktów.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ścieżka do obrazu reprezentującego grupę produktów.
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// Lista produktów w grupie.
        /// </summary>
        public List<ProductItem> Products { get; set; }
        // Zastąpienie List<ProductItem> na List<string> może być konieczne jeśli JSON się wysypie
        // string będzie zawierał ID produktu, a nie cały obiekt ProductItem

        public ProductGroup(string name, string description, string imagePath, List<ProductItem> products)
        {
            Name = name;
            Description = description;
            ImagePath = imagePath;
            Products = products;
        }


    }
}
