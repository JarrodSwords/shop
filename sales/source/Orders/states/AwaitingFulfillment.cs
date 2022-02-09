using Jgs.Ddd;
using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public class AwaitingFulfillment : State
        {
            #region Creation

            public AwaitingFulfillment(Order order) : base(order)
            {
            }

            #endregion

            #region Public Interface

            public override Result<Error> Add(Orders.LineItem lineItem) =>
                CreateInvalidOperation("Order awaiting fulfillment cannot be altered.");

            public override Result<Error> ApplyPayment(Money payment) =>
                CreateInvalidOperation("Cannot apply payment to a completed order.");

            public override Result<Error> Cancel()
            {
                Status = OrderStatus.Canceled;
                return Success();
            }

            public override Result<Error> Confirm() => CreateInvalidOperation("Cannot confirm a completed order.");
            public override Result<Error> IssueRefund() => CreateInvalidOperation("Cancel order first.");

            public override Result<Error> Remove(Id lineItemId) =>
                CreateInvalidOperation("Order awaiting fulfillment cannot be altered.");

            public override Result<Error> Submit() => CreateInvalidOperation("Order already submitted.");

            #endregion
        }
    }
}
