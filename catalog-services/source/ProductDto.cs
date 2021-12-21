namespace Shop.Catalog.Services
{
    public record ProductDto(
        string Description,
        string Name,
        decimal Price,
        string RecordName
    )
    {
        #region Creation

        private ProductDto(Product source) : this(
            source.Description,
            source.Name,
            source.Price,
            source.RecordName
        )
        {
        }

        public static ProductDto From(Product source) => new(source);

        #endregion
    }
}
