using Shop.Shared;

namespace Shop.Sales
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Find(Sku sku);
        IProductRepository Update(Product product);
    }
}
