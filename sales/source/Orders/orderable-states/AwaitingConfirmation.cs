using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public class AwaitingConfirmation : Orderable
    {
        #region Creation

        public AwaitingConfirmation(Finances finances, OrderState state) : base(finances, state)
        {
        }

        #endregion

        #region Public Interface

        public override Result<Error> ApplyPayment(Money value)
        {
            Finances = Finances.ApplyPayment(value);

            State = Finances.IsPaidInFull
                ? OrderState.SaleComplete
                : OrderState.AwaitingPayment;

            return Success();
        }

        public override Result<Error> Cancel()
        {
            State = OrderState.Canceled;
            return Success();
        }

        public override Result<Error> Confirm()
        {
            State = OrderState.AwaitingPayment;
            return Success();
        }

        public override Result<Error> IssueRefund() =>
            InvalidOperation("Cannot refund an order awaiting confirmation.");

        #endregion
    }
}
