using Jgs.Ddd;
using Shop.Domain.Sales;

namespace Shop.Infrastructure.Sales
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        #region Creation

        public OrderRepository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IOrderRepository Implementation

        public Id Create(Domain.Sales.Order order)
        {
            _context.Order.Add(order);
            return order.Id;
        }

        #endregion
    }
}
