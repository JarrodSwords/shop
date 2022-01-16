using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;
using Shop.Sales.Orders;

namespace Shop.Sales.Spec
{
    public class ObjectProvider
    {
        private static readonly Id CouplesBoxId = new();
        private static readonly List<Id> CustomerIds = new() { new Id() };
        private static readonly Id LunchBoxId = new();

        #region Static Interface

        public static Order CreatePendingOrder() =>
            Order.From(
                CustomerIds.First(),
                CustomerIds,
                OrderStatus.Pending
            ).Value;

        public static LineItem CreateCouplesBox() => new(49, CouplesBoxId);
        public static LineItem CreateLunchBox() => new(25, LunchBoxId);

        public static Order CreateOrderAwaitingConfirmation(params LineItem[] lineItems)
        {
            var order = CreatePendingOrder();

            if (lineItems.Length == 0)
            {
                order.Add(new(25, LunchBoxId));
                order.Add(new(25, LunchBoxId));
                order.Add(new(49, CouplesBoxId));
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
            var order = CreateOrderAwaitingConfirmation();
            order.Confirm();
            order.ApplyPayment(99);
            return order;
        }

        #endregion
    }
}
