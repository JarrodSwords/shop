using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders.State
{
    public class AwaitingConfirmation : Order.State
    {
        #region Public Interface

        public override Result<Error> Cancel()
        {
            Set(OrderStates.Canceled);
            return Result<Error>.Success();
        }

        #endregion
    }
}
