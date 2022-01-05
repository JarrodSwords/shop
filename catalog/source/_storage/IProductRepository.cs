using Shop.Shared;

namespace Shop.Catalog
{
    public interface IProductRepository : IRepository<Product>
    {
        IProductRepository Create(Product product);
        IProductRepository Create(params Product[] products);
        bool Exists(Sku sku);
    }
}
