﻿using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAnOrderAwaitingPayment : Context
    {
        private readonly Order _order;

        #region Creation

        public GivenAnOrderAwaitingPayment()
        {
            _order = Order.From(
                CustomerId,
                CustomerIds,
                default,
                new LineItem(25m, new Id(), 1)
            ).Value;

            _order.Confirm();
        }

        #endregion

        public class WhenCanceled : GivenAnOrderAwaitingPayment
        {
            #region Test Methods

            [Fact]
            public void ThenOrderIsCanceled()
            {
                _order.Cancel();

                _order.State.Should().Be(OrderState.Canceled);
            }

            #endregion
        }

        public class WhenConfirmed : GivenAnOrderAwaitingPayment
        {
            #region Test Methods

            [Fact]
            public void ThenReturnInvalidOperationError()
            {
                var error = _order.Confirm().Error;

                error.Should().Be(Error.InvalidOperation());
            }

            #endregion
        }

        public class WhenPaymentReceived : GivenAnOrderAwaitingPayment
        {
            #region Test Methods

            [Fact]
            public void ThenFinancesAreUpdated()
            {
                var expected = new Finances(0, 30, 25, 5);

                _order.ApplyPayment(30);

                _order.Finances.Should().Be(expected);
            }

            [Fact]
            public void WithInsufficientAmount_ThenOrderIsAwaitingPayment()
            {
                _order.ApplyPayment(5);

                _order.State.Should().Be(OrderState.AwaitingPayment);
            }

            [Fact]
            public void WithSufficientAmount_ThenOrderIsAwaitingFulfillment()
            {
                _order.ApplyPayment(30);

                _order.State.Should().Be(OrderState.AwaitingFulfillment);
            }

            #endregion
        }
    }
}
