using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public class SaleComplete : Orderable
    {
        #region Creation

        public SaleComplete(Finances finances, OrderState state) : base(finances, state)
        {
        }

        #endregion

        #region Public Interface

        public override Result<Error> ApplyPayment(Money value) =>
            InvalidOperation("Cannot apply payment to a completed order.");

        public override Result<Error> Cancel()
        {
            State = OrderState.Canceled;
            return Success();
        }

        public override Result<Error> Confirm() => InvalidOperation("Cannot confirm a completed order.");

        public override Result<Error> IssueRefund()
        {
            State = OrderState.Canceled | OrderState.Refunded;
            return Success();
        }

        #endregion
    }
}
