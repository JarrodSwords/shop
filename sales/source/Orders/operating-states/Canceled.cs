﻿using Jgs.Functional.Explicit;
using Shop.Shared;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public class Canceled : Order.OperatingState
    {
        #region Public Interface

        public override Result<Error> Cancel() => InvalidOperation("Order already canceled.");
        public override Result<Error> Confirm() => InvalidOperation("Canceled order cannot be confirmed.");

        #endregion
    }
}
