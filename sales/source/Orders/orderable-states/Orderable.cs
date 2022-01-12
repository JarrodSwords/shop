using System;
using System.Collections.Generic;
using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public abstract class Orderable : IOrderable
    {
        private static readonly Dictionary<OrderState, Func<Finances, OrderState, Orderable>>
            OperatingStateFactory =
                new()
                {
                    { OrderState.AwaitingConfirmation, (f, s) => new AwaitingConfirmation(f, s) },
                    { OrderState.AwaitingPayment, (f, s) => new AwaitingPayment(f, s) },
                    { OrderState.Canceled, (f, s) => new Canceled(f, s) },
                    { OrderState.Canceled | OrderState.Refunded, (f, s) => new Canceled(f, s) },
                    { OrderState.SaleComplete, (f, s) => new SaleComplete(f, s) }
                };

        protected Order Order;

        #region Creation

        protected Orderable(
            Finances finances,
            OrderState state
        )
        {
            Finances = finances;
            State = state;
        }

        public static Orderable From(
            Finances finances,
            OrderState state
        ) =>
            OperatingStateFactory[state](finances, state);

        #endregion

        #region Public Interface

        public Finances Finances { get; protected set; }
        public OrderState State { get; protected set; }

        #endregion

        #region IOrderable Implementation

        public abstract Result<Error> ApplyPayment(Money value);
        public abstract Result<Error> Cancel();
        public abstract Result<Error> Confirm();
        public abstract Result<Error> IssueRefund();

        #endregion
    }
}
