﻿using System;
using Jgs.Functional.Explicit;
using Shop.Shared;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public class Canceled : Orderable
    {
        #region Creation

        public Canceled(Finances finances, OrderState state) : base(finances, state)
        {
        }

        #endregion

        #region Public Interface

        public override Result<Error> ApplyPayment(Money value) =>
            InvalidOperation("Cannot apply payment to a canceled order.");

        public override Result<Error> Cancel() => InvalidOperation("Order already canceled.");
        public override Result<Error> Confirm() => InvalidOperation("Canceled order cannot be confirmed.");
        public override Result<Error> IssueRefund() => throw new NotImplementedException();

        #endregion
    }
}
