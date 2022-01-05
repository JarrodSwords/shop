using Jgs.Functional;
using Shop.Shared;

namespace Shop.Catalog
{
    public interface IProductRepository : IRepository<Product>
    {
        Result Create(Product product);
        IProductRepository Create(params Product[] products);
    }
}
