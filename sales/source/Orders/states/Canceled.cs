using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public class Canceled : State
    {
        #region Creation

        public Canceled(Finances finances, OrderStatus status) : base(finances, status)
        {
        }

        #endregion

        #region Public Interface

        public override Result<Error> ApplyPayment(Money value) =>
            InvalidOperation("Cannot apply payment to a canceled order.");

        public override Result<Error> Cancel() => InvalidOperation("Order already canceled.");
        public override Result<Error> Confirm() => InvalidOperation("Canceled order cannot be confirmed.");

        public override Result<Error> IssueRefund()
        {
            Finances = Finances.IssueRefund();
            Status = OrderStatus.Refunded;
            return Success();
        }

        #endregion
    }
}
