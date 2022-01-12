using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public class AwaitingPayment : Orderable
    {
        #region Creation

        public AwaitingPayment(Finances finances, OrderState state) : base(finances, state)
        {
        }

        #endregion

        #region Public Interface

        public override Result<Error> ApplyPayment(Money value)
        {
            Finances = Finances.ApplyPayment(value);

            if (Finances.IsPaidInFull)
                State = OrderState.SaleComplete;

            return Success();
        }

        public override Result<Error> Cancel()
        {
            State = OrderState.Canceled;
            return Success();
        }

        public override Result<Error> Confirm() => InvalidOperation("Order already confirmed.");

        public override Result<Error> IssueRefund()
        {
            State = OrderState.Canceled | OrderState.Refunded;
            return Success();
        }

        #endregion
    }
}
