using Jgs.Ddd;
using Shop.Sales;
using DomainOrder = Shop.Sales.Order;

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

        public Id Create(DomainOrder order) => base.Create(order);

        #endregion
    }
}
