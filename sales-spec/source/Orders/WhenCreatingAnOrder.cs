﻿using System;
using FluentAssertions;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class WhenCreatingAnOrder : Context
    {
        #region Test Methods

        [Fact]
        public void ThenSubtotalIsSumOfLineItems()
        {
            var order = Order.From(
                CustomerId,
                CustomerIds,
                OrderStatus.AwaitingConfirmation,
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

            error.Should().Be(Error.Required());
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

            order.Finances.Tip.Should().Be(Money.Zero);
        }

        [Fact]
        public void WithState_ThenStateIsSet()
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
