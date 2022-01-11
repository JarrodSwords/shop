using System;
using System.Collections.Generic;
using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public abstract class OperatingState
        {
            private static readonly Dictionary<OrderState, Func<OperatingState>> OperatingStateFactory =
                new()
                {
                    { OrderState.AwaitingConfirmation, () => new AwaitingConfirmation() },
                    { OrderState.AwaitingPayment, () => new AwaitingPayment() },
                    { OrderState.Canceled, () => new Canceled() }
                };

            protected Order Order;

            #region Creation

            public static OperatingState From(OrderState state) => OperatingStateFactory[state]();

            #endregion

            #region Public Interface

            public abstract Result<Error> Cancel();
            public abstract Result<Error> Confirm();

            public void Set(Order order)
            {
                Order = order;
            }

            public void Set(OrderState states)
            {
                Order.State = states;
            }

            public void SetAmountDue(Money value)
            {
                Order.AmountDue = value;
            }

            #endregion
        }
    }
}
