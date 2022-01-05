using System.Linq;
using Jgs.Functional;
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

        public Result Create(DomainProduct product) => base.Create(product);

        public IProductRepository Create(params DomainProduct[] products)
        {
            base.Create(products.Select(Product.From).ToArray());
            return this;
        }

        #endregion
    }
}
