using Shop.Shared;

namespace Shop.Sales
{
    public interface IOrderRepository : IRepository<Order>
    {
        IOrderRepository Create(Order order);
    }
}
