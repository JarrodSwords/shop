using System.Linq;
using Shop.Catalog;
using DomainProduct = Shop.Catalog.Product;

namespace Shop.Write.Catalog
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        #region Creation

        public ProductRepository(Context context) : base(context)
        {
        }

        #endregion

        #region IProductRepository Implementation

        public IProductRepository Create(DomainProduct product)
        {
            base.Create(product);
            return this;
        }

        public IProductRepository Create(params DomainProduct[] products)
        {
            Create(products.Select(Product.From).ToArray());
            return this;
        }

        public bool Exists(Sku sku) => Exists(x => x.Sku == sku);

        #endregion
    }
}
