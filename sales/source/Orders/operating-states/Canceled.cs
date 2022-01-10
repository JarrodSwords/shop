using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public class Canceled : Order.OperatingState
    {
        #region Public Interface

        public override Result<Error> Cancel() => Error.InvalidOperation("Order already canceled.");
        public override Result<Error> Confirm() => Error.InvalidOperation("Canceled order cannot be confirmed.");

        #endregion
    }
}
