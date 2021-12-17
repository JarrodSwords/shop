using Jgs.Ddd;
using Shop.Sales;
using DomainOrder = Shop.Sales.Order;

namespace Shop.Infrastructure.Sales
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        #region Creation

        public OrderRepository(Context context) : base(context)
        {
        }

        #endregion

        #region IOrderRepository Implementation

        public Id Create(DomainOrder order) => Create(order);

        #endregion
    }
}
