using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public class AwaitingPayment : Order.OperatingState
    {
        #region Public Interface

        public override Result<Error> Cancel()
        {
            Set(OrderState.Canceled);
            return Result<Error>.Success();
        }

        public override Result<Error> Confirm() => Error.InvalidOperation("Order already confirmed.");

        #endregion
    }
}
