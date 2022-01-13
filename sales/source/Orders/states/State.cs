using System;
using System.Collections.Generic;
using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public abstract class State
    {
        private static readonly Dictionary<OrderStatus, Func<Finances, OrderStatus, State>>
            OperatingStateFactory =
                new()
                {
                    { OrderStatus.AwaitingConfirmation, (f, s) => new AwaitingConfirmation(f, s) },
                    { OrderStatus.AwaitingPayment, (f, s) => new AwaitingPayment(f, s) },
                    { OrderStatus.Canceled, (f, s) => new Canceled(f, s) },
                    { OrderStatus.Canceled | OrderStatus.Refunded, (f, s) => new Canceled(f, s) },
                    { OrderStatus.SaleComplete, (f, s) => new SaleComplete(f, s) }
                };

        protected Order Order;

        #region Creation

        protected State(
            Finances finances,
            OrderStatus status
        )
        {
            Finances = finances;
            Status = status;
        }

        public static State From(
            Finances finances,
            OrderStatus status
        ) =>
            OperatingStateFactory[status](finances, status);

        #endregion

        #region Public Interface

        public Finances Finances { get; protected set; }
        public OrderStatus Status { get; protected set; }

        public abstract Result<Error> ApplyPayment(Money value);
        public abstract Result<Error> Cancel();
        public abstract Result<Error> Confirm();
        public abstract Result<Error> IssueRefund();

        #endregion
    }
}
