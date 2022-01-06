using Shop.Sales.Customers;
using Shop.Sales.Orders;
using Shop.Sales.Products;

namespace Shop.Sales
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        void Commit();
    }
}
