using System.Linq;
using Shop.Sales.Orders;
using Shop.Shared;

namespace Shop.Sales.Spec
{
    public class OrderHelper
    {
        #region Static Interface

        public static Money CalculateBalance(Order order) =>
            order.LineItems.Aggregate(Money.Zero, (current, x) => current += x.Price);

        #endregion
    }
}
