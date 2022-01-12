﻿using FluentAssertions;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAnOrderAwaitingFulfillment : Context
    {
        #region Core

        private readonly Order _order;

        public GivenAnOrderAwaitingFulfillment()
        {
            _order = Order.From(
                CustomerId,
                CustomerIds,
                OrderState.AwaitingFulfillment
            ).Value;
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenApplyingPayment_ThenReturnInvalidOperationError()
        {
            var error = _order.ApplyPayment(1).Error;

            error.Should().Be(Error.InvalidOperation());
        }

        [Fact]
        public void WhenCanceled_ThenReturnInvalidOperationError()
        {
            var error = _order.Cancel().Error;

            error.Should().Be(Error.InvalidOperation());
        }

        [Fact]
        public void WhenConfirmed_ThenReturnInvalidOperationError()
        {
            var error = _order.Confirm().Error;

            error.Should().Be(Error.InvalidOperation());
        }

        #endregion
    }
}
