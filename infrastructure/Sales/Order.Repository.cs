using Jgs.Ddd;
using Shop.Domain.Sales;
using DomainOrder = Shop.Domain.Sales.Order;

namespace Shop.Infrastructure.Sales
{
    public partial class Order
    {
        internal class Repository : Repository<Order>, IOrderRepository
        {
            #region Creation

            public Repository(Context context) : base(context)
            {
            }

            #endregion

            #region IOrderRepository Implementation

            public Id Create(DomainOrder order) => base.Create(order);

            #endregion
        }
    }
}
