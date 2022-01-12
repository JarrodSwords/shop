using System;
using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public class Refunded : Order.Orderable
    {
        #region Public Interface

        public override Result<Error> ApplyPayment(Money value) => throw new NotImplementedException();
        public override Result<Error> Cancel() => throw new NotImplementedException();
        public override Result<Error> Confirm() => throw new NotImplementedException();
        public override Result<Error> Refund() => throw new NotImplementedException();

        #endregion
    }
}
