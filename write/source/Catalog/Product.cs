using Shop.Catalog;
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
            Size = source.Size;
            Sku = source.Sku;
            SetCategories(source.Categories);
        }

        public static Product From(CatalogProduct source) => new(source);

        #endregion

        #region Public Interface

        public bool IsBox { get; set; }
        public bool IsDessert { get; set; }
        public bool IsSide { get; set; }

        public Product SetCategories(ProductCategories categories)
        {
            IsBox = categories.HasFlag(ProductCategories.Box);
            IsDessert = categories.HasFlag(ProductCategories.Dessert);
            IsSide = categories.HasFlag(ProductCategories.Side);
            return this;
        }

        #endregion

        #region Static Interface

        public static implicit operator Product(CatalogProduct source) => new(source);

        #endregion
    }
}
