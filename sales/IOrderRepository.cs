using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales
{
    public interface IOrderRepository : IRepository<Order>
    {
        Id Create(Order order);
    }
}
