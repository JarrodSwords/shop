using System;
using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;

namespace Shop.Sales.Orders
{
    public class AwaitingConfirmation : Order.Orderable
    {
        #region Public Interface

        public override Result<Error> ApplyPayment(Money money) => throw new NotImplementedException();

        public override Result<Error> Cancel()
        {
            Set(OrderState.Canceled);
            return Success();
        }

        public override Result<Error> Confirm()
        {
            SetAmountDue(Order.Subtotal);
            Set(OrderState.AwaitingPayment);
            return Success();
        }

        #endregion
    }
}
