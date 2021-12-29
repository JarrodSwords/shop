namespace Shop.Catalog.Services
{
    public record ProductDto(
        string Description,
        string Name,
        string Sku
    )
    {
        #region Creation

        private ProductDto(Product source) : this(
            source.Description,
            source.Name,
            source.Sku
        )
        {
        }

        public static ProductDto From(Product source) => new(source);

        #endregion
    }
}
