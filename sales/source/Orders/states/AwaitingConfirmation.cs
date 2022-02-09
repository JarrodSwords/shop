using System.Linq;
using Jgs.Ddd;
using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Sales.Orders.ErrorExtensions;
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

            public override Result<Error> Add(Orders.LineItem lineItem)
            {
                Order._lineItems.Add(lineItem);
                return Success();
            }

            public override Result<Error> ApplyPayment(Money payment)
            {
                Finances = Finances.ApplyPayment(payment);

                Status = Finances.IsPaidInFull
                    ? OrderStatus.AwaitingFulfillment
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
                CreateInvalidOperation("Cannot refund an order awaiting confirmation.");

            public override Result<Error> Remove(Id lineItemId)
            {
                if (Order._lineItems.All(x => x.Id != lineItemId))
                    return LineItemNotFound();

                Order._lineItems.Remove(x => x.Id == lineItemId);

                return Success();
            }

            public override Result<Error> Submit() => CreateInvalidOperation("Order already submitted.");

            #endregion
        }
    }
}
