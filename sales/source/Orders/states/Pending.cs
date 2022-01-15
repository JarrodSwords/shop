using System;
using Jgs.Functional.Explicit;
using Shop.Shared;
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

            public override Result<Error> ApplyPayment(Money value) => throw new NotImplementedException();

            public override Result<Error> Cancel() => throw new NotImplementedException();

            public override Result<Error> Confirm() => throw new NotImplementedException();

            public override Result<Error> IssueRefund() => throw new NotImplementedException();

            public override Result<Error> Submit() => InvalidOperation();

            #endregion
        }
    }
}
