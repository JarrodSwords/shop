using Jgs.Ddd;
using Shop.Infrastructure;
using DomainOrder = Shop.Sales.Order;
using Entity = Shop.Infrastructure.Entity;

namespace Shop.Sales.Infrastructure
{
    public class Order : Entity
    {
        public class Repository : Repository<Order>, IOrderRepository
        {
            #region Creation

            public Repository(Context context) : base(context)
            {
            }

            #endregion

            #region IOrderRepository Implementation

            public Id Create(DomainOrder order) => Create(order);

            #endregion
        }
    }
}
