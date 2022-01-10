using System;
using System.Collections.Generic;
using Jgs.Functional.Explicit;
using Shop.Sales.Orders.State;
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
                    { OrderState.Canceled, () => new Canceled() }
                };

            protected Order Order;

            #region Creation

            public static OperatingState From(OrderState state) => OperatingStateFactory[state]();

            #endregion

            #region Public Interface

            public abstract Result<Error> Cancel();

            public void Set(Order order)
            {
                Order = order;
            }

            public void Set(OrderState states)
            {
                Order.State = states;
            }

            #endregion
        }
    }
}
