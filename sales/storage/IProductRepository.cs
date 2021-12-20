using System;
using Shop.Shared;

namespace Shop.Sales
{
    public interface IProductRepository : IRepository<Product>
    {
        Guid Create(Product product);
    }
}
