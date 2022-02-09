using System;
using Jgs.Ddd;
using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public class Canceled : State
        {
            #region Creation

            public Canceled(Order order) : base(order)
            {
            }

            #endregion

            #region Public Interface

            public override Result<Error> Add(Orders.LineItem lineItem) => throw new NotImplementedException();

            public override Result<Error> ApplyPayment(Money payment) =>
                CreateInvalidOperation("Cannot apply payment to a canceled order.");

            public override Result<Error> Cancel() => CreateInvalidOperation("Order already canceled.");
            public override Result<Error> Confirm() => CreateInvalidOperation("Canceled order cannot be confirmed.");

            public override void EnterState()
            {
                Finances = Finances.Cancel();
            }

            public override Result<Error> IssueRefund()
            {
                if (Finances.Paid == 0 || Finances.Paid == Finances.Refunded)
                    return CreateInvalidOperation("No refund necessary.");

                Finances = Finances.IssueRefund();
                Status = OrderStatus.Refunded;
                return Success();
            }

            public override Result<Error> Remove(Id lineItemId) => CreateInvalidOperation();
            public override Result<Error> Submit() => CreateInvalidOperation("Order already submitted.");

            #endregion
        }
    }
}
