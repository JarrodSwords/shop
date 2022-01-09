using SalesProduct = Shop.Sales.Products.Product;

namespace Shop.Write
{
    public partial class Product
    {
        #region Public Interface

        public decimal Price { get; set; }

        public Product Update(SalesProduct product)
        {
            Price = product.Price;
            return this;
        }

        #endregion

        #region Static Interface

        public static implicit operator SalesProduct(Product source) =>
            new(
                source.GetCategories(),
                source.Price,
                source.Sku,
                source.Id
            );

        #endregion
    }
}
