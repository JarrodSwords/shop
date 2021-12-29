using CatalogProduct = Shop.Catalog.Product;

namespace Shop.Write
{
    public partial class Product
    {
        #region Creation

        public Product(CatalogProduct source) : base(source.Id)
        {
            CompanyId = source.CompanyId;
            Description = source.Description;
            Name = source.Name;
            Sku = source.Sku;
        }

        public static Product From(CatalogProduct source) => new(source);

        #endregion

        #region Static Interface

        public static implicit operator Product(CatalogProduct source) => new(source);

        #endregion
    }
}
