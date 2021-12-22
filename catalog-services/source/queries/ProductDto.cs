namespace Shop.Catalog.Services
{
    public record ProductDto(
        string Description,
        string Name,
        string RecordName
    )
    {
        #region Creation

        private ProductDto(Product source) : this(
            source.Description,
            source.Name,
            source.RecordName
        )
        {
        }

        public static ProductDto From(Product source) => new(source);

        #endregion
    }
}
