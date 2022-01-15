using System;
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

            public override Result<Error> ApplyPayment(Money value) =>
                InvalidOperation("Cannot apply payment to a canceled order.");

            public override Result<Error> Cancel() => InvalidOperation("Order already canceled.");
            public override Result<Error> Confirm() => InvalidOperation("Canceled order cannot be confirmed.");

            public override void EnterState()
            {
                Finances = Finances.Cancel();
            }

            public override Result<Error> IssueRefund()
            {
                if (Finances.Paid == 0 || Finances.Paid == Finances.Refunded)
                    return InvalidOperation("No refund necessary.");

                Finances = Finances.IssueRefund();
                Status = OrderStatus.Refunded;
                return Success();
            }

            public override Result<Error> Submit() => throw new NotImplementedException();

            #endregion
        }
    }
}
