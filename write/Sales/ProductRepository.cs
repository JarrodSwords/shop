using System;
using Shop.Sales;
using DomainProduct = Shop.Sales.Product;

namespace Shop.Write.Sales
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        #region Creation

        public ProductRepository(Context context) : base(context)
        {
        }

        #endregion

        #region Public Interface

        public Guid Create(DomainProduct product) => base.Create(product);

        #endregion
    }
}
