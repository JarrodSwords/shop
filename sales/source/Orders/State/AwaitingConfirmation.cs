using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders.State
{
    public class AwaitingConfirmation : OrderState
    {
        #region Public Interface

        public override Result<Error> Cancel()
        {
            Order.Set(new Canceled());
            return Result<Error>.Success();
        }

        public override OrderStates GetStates() => OrderStates.AwaitingConfirmation;

        #endregion
    }
}
