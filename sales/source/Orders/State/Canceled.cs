using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders.State
{
    public class Canceled : OrderState
    {
        #region Public Interface

        public override Result<Error> Cancel() => ErrorExtensions.OrderAlreadyCanceled();
        public override OrderStates GetStates() => OrderStates.Canceled;

        #endregion
    }
}
