using System;
using Shop.Shared;

namespace Shop.Catalog
{
    public interface IProductRepository : IRepository<Product>
    {
        Guid Create(Product product);
    }
}
