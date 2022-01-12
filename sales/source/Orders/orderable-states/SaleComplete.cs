using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public class SaleComplete : Order.Orderable
    {
        #region Public Interface

        public override Result<Error> ApplyPayment(Money value) =>
            InvalidOperation("Cannot apply payment to a completed order.");

        public override Result<Error> Cancel() => InvalidOperation("Cannot cancel a completed order.");
        public override Result<Error> Confirm() => InvalidOperation("Cannot confirm a completed order.");

        public override Result<Error> Refund()
        {
            Set(OrderState.Canceled | OrderState.Refunded);
            return Success();
        }

        #endregion
    }
}
