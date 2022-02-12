using System.Linq;
using Jgs.Functional.Explicit;
using Shop.Shared;
using static Jgs.Functional.Explicit.Result<Shop.Shared.Error>;
using static Shop.Sales.Orders.ErrorExtensions;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public class Pending : State
        {
            #region Creation

            public Pending(Order order) : base(order)
            {
            }

            #endregion

            #region Public Interface

            public override Result<Error> Add(LineItem lineItem)
            {
                Order._lineItems.Add(LineItemEntity.From(lineItem, Order.Id));
                return Success();
            }

            public override Result<Error> ApplyPayment(Money payment) => CreateInvalidOperation();

            public override Result<Error> Cancel()
            {
                Status = OrderStatus.Canceled;
                return Success();
            }

            public override Result<Error> Confirm() => CreateInvalidOperation();
            public override Result<Error> IssueRefund() => CreateInvalidOperation();

            public override Result<Error> Remove(LineItem lineItem)
            {
                if (Order._lineItems.Select(x => x.Value).All(x => x != lineItem))
                    return LineItemNotFound();

                Order._lineItems.RemoveLast(x => x.Value == lineItem);

                return Success();
            }

            public override Result<Error> Submit()
            {
                if (!Order.HasLineItems)
                    return CreateInvalidOperation("Cannot submit empty order.");

                Status = OrderStatus.AwaitingConfirmation;

                return Success();
            }

            #endregion
        }
    }
}
