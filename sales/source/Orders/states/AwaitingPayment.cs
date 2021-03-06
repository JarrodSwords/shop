using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public class AwaitingPayment : State
        {
            #region Creation

            public AwaitingPayment(Order order) : base(order)
            {
            }

            #endregion

            #region Public Interface

            public override Result<Error> Add(LineItem lineItem) =>
                CreateInvalidOperation("Confirmed order cannot be altered.");

            public override Result<Error> ApplyPayment(Money payment)
            {
                Finances = Finances.ApplyPayment(payment);

                if (Finances.IsPaidInFull)
                    Status = OrderStatus.AwaitingFulfillment;

                return Success();
            }

            public override Result<Error> Cancel()
            {
                Status = OrderStatus.Canceled;
                return Success();
            }

            public override Result<Error> Confirm() => CreateInvalidOperation("Order already confirmed.");
            public override Result<Error> IssueRefund() => CreateInvalidOperation("Cancel order first.");

            public override Result<Error> Remove(LineItem lineItem) =>
                CreateInvalidOperation("Confirmed order cannot be altered.");

            public override Result<Error> Submit() => CreateInvalidOperation("Order already submitted.");

            #endregion
        }
    }
}
