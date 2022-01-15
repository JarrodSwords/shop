using System;
using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public class SaleComplete : State
        {
            #region Creation

            public SaleComplete(Order order) : base(order)
            {
            }

            #endregion

            #region Public Interface

            public override Result<Error> Add(LineItem lineItem) => throw new NotImplementedException();

            public override Result<Error> ApplyPayment(Money value) =>
                CreateInvalidOperation("Cannot apply payment to a completed order.");

            public override Result<Error> Cancel()
            {
                Status = OrderStatus.Canceled;
                return Success();
            }

            public override Result<Error> Confirm() => CreateInvalidOperation("Cannot confirm a completed order.");

            public override Result<Error> IssueRefund()
            {
                Status = OrderStatus.Canceled | OrderStatus.Refunded;
                return Success();
            }

            public override Result<Error> Submit() => throw new NotImplementedException();

            #endregion
        }
    }
}
