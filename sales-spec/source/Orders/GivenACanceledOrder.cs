﻿using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Sales.Spec.Orders.OrderProvider;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public class GivenACanceledOrder
    {
        #region Core

        private readonly Order _order;

        public GivenACanceledOrder()
        {
            _order = CreateOrder();
            _order.Cancel();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenApplyingPayment_ThenReturnInvalidOperationError()
        {
            var error = _order.ApplyPayment(1).Error;

            error.Should().Be(InvalidOperation());
        }

        [Fact]
        public void WhenCanceled_ThenReturnInvalidOperationError()
        {
            var error = _order.Cancel().Error;

            error.Should().Be(InvalidOperation());
        }

        [Fact]
        public void WhenConfirmed_ThenReturnInvalidOperationError()
        {
            var error = _order.Confirm().Error;

            error.Should().Be(InvalidOperation());
        }

        [Fact]
        public void WhenRefunded_ThenReturnInvalidOperationError()
        {
            var error = _order.IssueRefund().Error;

            error.Should().Be(InvalidOperation());
        }

        #endregion

        public class WithOutstandingRefund
        {
            #region Core

            private readonly Order _order;

            public WithOutstandingRefund()
            {
                _order = CreateOrder();
                _order.ApplyPayment(20);
                _order.Cancel();
            }

            #endregion

            #region Test Methods

            [Fact]
            public void WhenRefunded_ThenOrderIsRefunded()
            {
                _order.IssueRefund();

                _order.Status.Should().Be(OrderStatus.Refunded);
            }

            #endregion
        }
    }
}
