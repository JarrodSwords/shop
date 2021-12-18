﻿using FluentAssertions;
using Xunit;

namespace Shop.Sales.Spec.GivenASubmittedOrder
{
    public class WhenCancelled
    {
        #region Core

        private readonly Order _order = ObjectProvider.CreateSubmittedOrder();

        public WhenCancelled()
        {
            _order.Cancel();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ThenCancellationDateIsSet()
        {
            _order.CancellationDate.Should().NotBeNull();
        }

        [Fact]
        public void ThenOrderIsCancelled()
        {
            _order.IsCancelled.Should().BeTrue();
        }

        [Fact]
        public void ThenOrderIsNotAwaitingFulfillment()
        {
            _order.IsAwaitingFulfillment.Should().BeFalse();
        }

        [Fact]
        public void ThenOrderIsNotAwaitingPayment()
        {
            _order.IsAwaitingPayment.Should().BeFalse();
        }

        #endregion
    }
}