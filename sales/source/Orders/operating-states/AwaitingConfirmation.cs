using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public class AwaitingConfirmation : Order.OperatingState
    {
        #region Public Interface

        public override Result<Error> Cancel()
        {
            Set(OrderState.Canceled);
            return Result<Error>.Success();
        }

        public override Result<Error> Confirm()
        {
            Set(OrderState.AwaitingPayment);
            return Result<Error>.Success();
        }

        #endregion
    }
}
