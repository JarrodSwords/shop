using System;
using System.Collections.Generic;
using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public abstract class State
        {
            private static readonly Dictionary<OrderStatus, Func<Order, State>>
                OperatingStateFactory =
                    new()
                    {
                        { OrderStatus.AwaitingConfirmation, x => new AwaitingConfirmation(x) },
                        { OrderStatus.AwaitingPayment, x => new AwaitingPayment(x) },
                        { OrderStatus.Canceled, x => new Canceled(x) },
                        { OrderStatus.Canceled | OrderStatus.Refunded, x => new Canceled(x) },
                        { OrderStatus.SaleComplete, x => new SaleComplete(x) }
                    };

            protected Order Order;

            #region Creation

            protected State(Order order)
            {
                Order = order;
            }

            public static State From(Order order) => OperatingStateFactory[order.Status](order);

            #endregion

            #region Public Interface

            public Finances Finances
            {
                get => Order.Finances;
                set => Order.Finances = value;
            }

            public OrderStatus Status
            {
                get => Order.Status;
                set => Order.Status = value;
            }

            public abstract Result<Error> ApplyPayment(Money value);
            public abstract Result<Error> Cancel();
            public abstract Result<Error> Confirm();
            public abstract Result<Error> IssueRefund();

            #endregion
        }
    }
}
