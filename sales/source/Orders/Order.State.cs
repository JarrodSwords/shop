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
            private readonly Order _order;

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

            #region Creation

            protected State(Order order)
            {
                _order = order;
            }

            public static State From(Order order) => OperatingStateFactory[order.Status](order);

            #endregion

            #region Public Interface

            public Finances Finances
            {
                get => _order.Finances;
                set => _order.Finances = value;
            }

            public OrderStatus Status
            {
                get => _order.Status;
                set => _order.Status = value;
            }

            public abstract Result<Error> ApplyPayment(Money value);
            public abstract Result<Error> Cancel();
            public abstract Result<Error> Confirm();
            public abstract void EnterState();
            public abstract Result<Error> IssueRefund();

            #endregion
        }
    }
}
