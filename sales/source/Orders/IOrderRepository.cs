using Shop.Shared;

namespace Shop.Sales.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
        IOrderRepository Create(Order order);
    }
}
