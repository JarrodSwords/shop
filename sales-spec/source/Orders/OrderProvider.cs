using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;
using Shop.Sales.Orders;

namespace Shop.Sales.Spec.Orders
{
    public class OrderProvider
    {
        private static readonly List<Id> CustomerIds = new() { new Id() };

        #region Static Interface

        public static Order CreateOrder() =>
            Order.From(
                CustomerIds.First(),
                CustomerIds,
                OrderStatus.AwaitingConfirmation,
                default,
                new LineItem(25, new Id(), 1)
            ).Value;

        #endregion
    }
}
