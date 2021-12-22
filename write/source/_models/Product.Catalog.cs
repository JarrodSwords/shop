namespace Shop.Write
{
    public partial class Product
    {
        #region Creation

        public Product(Shop.Catalog.Product source) : base(source.Id)
        {
            Description = source.Description;
            Name = source.Name;
            RecordName = source.RecordName;
        }

        #endregion

        #region Static Interface

        public static implicit operator Product(Shop.Catalog.Product source) => new(source);

        #endregion
    }
}
