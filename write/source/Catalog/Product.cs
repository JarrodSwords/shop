using CatalogProduct = Shop.Catalog.Product;

namespace Shop.Write
{
    public partial class Product
    {
        #region Creation

        public Product(CatalogProduct source) : base(source.Id)
        {
            VendorId = source.VendorId;
            Description = source.Description;
            Name = source.Name;
            Size = source.Size;
            Sku = source.Sku;
            SetCategories(source.Categories);
        }

        public static Product From(CatalogProduct source) => new(source);

        #endregion

        #region Static Interface

        public static implicit operator Product(CatalogProduct source) => new(source);

        #endregion
    }
}
