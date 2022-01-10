using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders.State
{
    public class Canceled : Order.State
    {
        #region Public Interface

        public override Result<Error> Cancel() => ErrorExtensions.OrderAlreadyCanceled();

        #endregion
    }
}
