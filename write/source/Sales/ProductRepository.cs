using Shop.Sales.Products;
using Shop.Shared;
using SalesProduct = Shop.Sales.Products.Product;

namespace Shop.Write.Sales
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        #region Creation

        public ProductRepository(Context context) : base(context)
        {
        }

        #endregion

        #region IProductRepository Implementation

        public SalesProduct Find(Sku sku) => Find(x => x.Sku == sku);

        public IProductRepository Update(SalesProduct product)
        {
            var storedProduct = Find(x => x.Sku == product.Sku).Update(product);
            base.Update(storedProduct);

            return this;
        }

        #endregion
    }
}
