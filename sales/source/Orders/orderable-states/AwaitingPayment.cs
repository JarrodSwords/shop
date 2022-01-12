using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public class AwaitingPayment : Order.Orderable
    {
        #region Public Interface

        public override Result<Error> ApplyPayment(Money value)
        {
            Finances = Order.Finances.ApplyPayment(value);

            if (Finances.IsPaidInFull)
                Set(OrderState.SaleComplete);

            return Success();
        }

        public override Result<Error> Cancel()
        {
            Set(OrderState.Canceled);
            return Success();
        }

        public override Result<Error> Confirm() => InvalidOperation("Order already confirmed.");

        public override Result<Error> Refund()
        {
            Set(OrderState.Refunded);
            return Success();
        }

        #endregion
    }
}
