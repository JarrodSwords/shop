using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public class AwaitingConfirmation : State
        {
            #region Creation

            public AwaitingConfirmation(Order order) : base(order)
            {
            }

            #endregion

            #region Public Interface

            public override Result<Error> ApplyPayment(Money value)
            {
                Finances = Finances.ApplyPayment(value);

                Status = Finances.IsPaidInFull
                    ? OrderStatus.SaleComplete
                    : OrderStatus.AwaitingPayment;

                return Success();
            }

            public override Result<Error> Cancel()
            {
                Status = OrderStatus.Canceled;
                return Success();
            }

            public override Result<Error> Confirm()
            {
                Status = OrderStatus.AwaitingPayment;
                return Success();
            }

            public override Result<Error> IssueRefund() =>
                InvalidOperation("Cannot refund an order awaiting confirmation.");

            #endregion
        }
    }
}
