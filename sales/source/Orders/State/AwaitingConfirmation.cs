using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders.State
{
    public class AwaitingConfirmation : Order.OperatingState
    {
        #region Public Interface

        public override Result<Error> Cancel()
        {
            Set(OrderState.Canceled);
            return Result<Error>.Success();
        }

        #endregion
    }
}
