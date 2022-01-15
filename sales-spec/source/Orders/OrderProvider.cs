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

        public static Order PendingOrder() =>
            Order.From(
                CustomerIds.First(),
                CustomerIds,
                OrderStatus.Pending
            ).Value;

        public static Order OrderAwaitingConfirmation(params LineItem[] lineItems)
        {
            var order = PendingOrder();

            if (lineItems.Length == 0)
            {
                order.Add(new(25, new Id(), 2));
                order.Add(new(49, new Id(), 1));
            }
            else
            {
                foreach (var i in lineItems)
                    order.Add(i);
            }

            order.Submit();

            return order;
        }

        public static Order CompletedOrder()
        {
            var order = OrderAwaitingConfirmation();
            order.Confirm();
            order.ApplyPayment(99);
            return order;
        }

        #endregion
    }
}
