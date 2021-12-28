using CatalogProduct = Shop.Catalog.Product;

namespace Shop.Write
{
    public partial class Product
    {
        #region Creation

        public Product(CatalogProduct source) : base(source.Id)
        {
            Description = source.Description;
            Name = source.Name;
        }

        #endregion

        #region Static Interface

        public static implicit operator Product(CatalogProduct source) => new(source);

        #endregion
    }
}
