using System;
using System.Collections.Generic;
using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public abstract class Orderable : IOrderable
        {
            private static readonly Dictionary<OrderState, Func<Orderable>> OperatingStateFactory =
                new()
                {
                    { OrderState.AwaitingConfirmation, () => new AwaitingConfirmation() },
                    { OrderState.AwaitingPayment, () => new AwaitingPayment() },
                    { OrderState.Canceled, () => new Canceled() },
                    { OrderState.Canceled | OrderState.Refunded, () => new Canceled() },
                    { OrderState.SaleComplete, () => new SaleComplete() }
                };

            protected Order Order;

            #region Creation

            public static Orderable From(OrderState state) => OperatingStateFactory[state]();

            #endregion

            #region Public Interface

            public void Set(Order order)
            {
                Order = order;
            }

            public void Set(OrderState states)
            {
                Order.State = states;
            }

            #endregion

            #region Protected Interface

            protected Finances Finances
            {
                get => Order.Finances;
                set => Order.Finances = value;
            }

            #endregion

            #region IOrderable Implementation

            public abstract Result<Error> ApplyPayment(Money value);
            public abstract Result<Error> Cancel();
            public abstract Result<Error> Confirm();
            public abstract Result<Error> Refund();

            #endregion
        }
    }
}
