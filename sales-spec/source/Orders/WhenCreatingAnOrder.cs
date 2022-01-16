using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;
using static Shop.Shared.Error;
using static Shop.Shared.Money;

namespace Shop.Sales.Spec.Orders
{
    public class WhenCreatingAnOrder
    {
        #region Core

        private readonly Id CustomerId;
        private readonly List<Id> CustomerIds = new() { new Id() };

        public WhenCreatingAnOrder()
        {
            CustomerId = CustomerIds.First();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ThenSubtotalIsSumOfLineItems()
        {
            var order = Order.From(
                CustomerId,
                CustomerIds,
                OrderStatus.Pending,
                default,
                new LineItem(25m, new Guid(), 1),
                new LineItem(49m, new Guid(), 2)
            ).Value;

            order.Finances.Subtotal.Should().Be((Money) 123);
        }

        [Fact]
        public void WithoutCustomerId_ThenReturnRequiredError()
        {
            var error = Order.From(
                null,
                null
            ).Error;

            error.Should().Be(Required());
        }

        [Fact]
        public void WithoutState_ThenStateIsAwaitingConfirmation()
        {
            var order = Order.From(
                CustomerId,
                CustomerIds
            ).Value;

            order.Status.Should().Be(OrderStatus.AwaitingConfirmation);
        }

        [Fact]
        public void WithoutTip_ThenTipIsZero()
        {
            var order = Order.From(
                CustomerId,
                CustomerIds
            ).Value;

            order.Finances.Tip.Should().Be(Zero);
        }

        [Fact]
        public void WithStatus_ThenStatusIsSet()
        {
            var order = Order.From(
                CustomerId,
                CustomerIds,
                OrderStatus.Canceled
            ).Value;

            order.Status.Should().Be(OrderStatus.Canceled);
        }

        [Fact]
        public void WithUnregisteredCustomerId_ThenReturnCustomerNotFoundError()
        {
            var error = Order.From(
                CustomerId,
                new()
            ).Error;

            error.Should().Be(ErrorExtensions.CustomerNotFound());
        }

        #endregion
    }
}
