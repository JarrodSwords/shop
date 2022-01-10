using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders.State
{
    public class Canceled : Order.OperatingState
    {
        #region Public Interface

        public override Result<Error> Cancel() => Error.InvalidOperation("Order already canceled.");

        #endregion
    }
}
