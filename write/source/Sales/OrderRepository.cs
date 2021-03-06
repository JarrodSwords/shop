using Shop.Sales.Orders;
using DomainOrder = Shop.Sales.Orders.Order;

namespace Shop.Write.Sales
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        #region Creation

        public OrderRepository(Context context) : base(context)
        {
        }

        #endregion

        #region IOrderRepository Implementation

        public IOrderRepository Create(DomainOrder order)
        {
            base.Create(order);
            return this;
        }

        #endregion
    }
}
