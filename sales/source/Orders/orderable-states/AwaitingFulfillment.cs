using Jgs.Functional.Explicit;
using Shop.Shared;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public class AwaitingFulfillment : Order.Orderable
    {
        #region Public Interface

        public override Result<Error> ApplyPayment(Money value) =>
            InvalidOperation("Cannot apply payment to a completed order.");

        public override Result<Error> Cancel() => InvalidOperation("Cannot cancel a completed order.");
        public override Result<Error> Confirm() => InvalidOperation("Cannot confirm a completed order.");

        #endregion
    }
}
