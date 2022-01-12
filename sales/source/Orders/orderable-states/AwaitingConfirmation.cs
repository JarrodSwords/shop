﻿using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;

namespace Shop.Sales.Orders
{
    public class AwaitingConfirmation : Order.Orderable
    {
        #region Public Interface

        public override Result<Error> ApplyPayment(Money value)
        {
            Finances = Finances.ApplyPayment(value);

            if (!Finances.IsPaidInFull)
                Set(OrderState.AwaitingPayment);

            return Success();
        }

        public override Result<Error> Cancel()
        {
            Set(OrderState.Canceled);
            return Success();
        }

        public override Result<Error> Confirm()
        {
            Set(OrderState.AwaitingPayment);
            return Success();
        }

        #endregion
    }
}
