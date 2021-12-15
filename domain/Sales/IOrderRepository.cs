using Jgs.Ddd;

namespace Shop.Domain.Sales
{
    public interface IOrderRepository : IRepository<Order>
    {
        Id Create(Order order);
    }
}
