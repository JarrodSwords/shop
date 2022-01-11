using System;
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
                default,
                new LineItem(25m, new Guid(), 1),
                new LineItem(49m, new Guid(), 2)
            ).Value;

            order.Subtotal.Should().Be((Money) 123);
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

            order.State.Should().Be(OrderState.AwaitingConfirmation);
        }

        [Fact]
        public void WithoutTip_ThenTipIsZero()
        {
            var order = Order.From(
                CustomerId,
                CustomerIds
            ).Value;

            order.Tip.Should().Be(Money.Zero);
        }

        [Fact]
        public void WithState_ThenStateIsSet()
        {
            var order = Order.From(
                CustomerId,
                CustomerIds,
                OrderState.Canceled
            ).Value;

            order.State.Should().Be(OrderState.Canceled);
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
