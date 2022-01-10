using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class WhenCreatingAnOrder
    {
        #region Core

        private readonly Id _customerId;

        private readonly List<Id> _customerIds = new() { new Id() };

        public WhenCreatingAnOrder()
        {
            _customerId = _customerIds.First();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WithoutCustomerId_ThenReturnRequiredError()
        {
            var error = Order.From(null, null, OrderStates.AwaitingPayment).Error;

            error.Should().Be(Error.Required());
        }

        [Fact]
        public void WithoutTip_ThenTipIsZero()
        {
            var order = Order.From(_customerId, _customerIds, OrderStates.AwaitingPayment).Value;

            order.Tip.Should().Be(Money.Zero);
        }

        [Fact]
        public void WithState_ThenStateIsSet()
        {
            var order = Order.From(
                _customerId,
                _customerIds,
                OrderStates.AwaitingPayment
            ).Value;

            order.States.Should().Be(OrderStates.AwaitingPayment);
        }

        [Fact]
        public void WithUnregisteredCustomerId_ThenReturnCustomerNotFoundError()
        {
            var error = Order.From(new Id(), new(), OrderStates.AwaitingPayment).Error;

            error.Should().Be(ErrorExtensions.CustomerNotFound());
        }

        #endregion
    }

    //public class GivenAnOrderRequest
    //{
    //    public class WhenCreatingAnOrder
    //    {
    //        #region Core

    //        private readonly SubmitOrder.OrderBuilder _builder;

    //        private readonly SubmitOrder _candidateOrder;
    //        private readonly Options _exclusions = Options.Cheese;
    //        private readonly Order _order;
    //        private readonly Result<Order> _result;

    //        public WhenCreatingAnOrder()
    //        {
    //            _candidateOrder = new SubmitOrder();
    //            _result = _builder.From(_candidateOrder).Build();
    //            _order = _result.Value;
    //        }

    //        #endregion

    //        #region Test Methods

    //        [Fact]
    //        public void ThenCustomerIdIsAssigned()
    //        {
    //            _order.CustomerId.Should().NotBeNull();
    //        }

    //        [Fact]
    //        public void ThenOptionsAreAppliedToEachLineItem()
    //        {
    //            _order.LineItems.Any(x => x.Exclusions != _exclusions).Should().BeFalse();
    //        }

    //        [Fact]
    //        public void ThenResultIsSuccess()
    //        {
    //            _result.IsSuccess.Should().BeTrue();
    //        }

    //        [Theory]
    //        [InlineData(1, 1, 0, 0, 1)]
    //        [InlineData(0, 0, 1, 1, 1)]
    //        [InlineData(1, 2, 3, 4, 14)]
    //        [InlineData(0.99, 1, 9, 1, 9.99)]
    //        public void ThenSubtotalIsAggregateOfLineItems(
    //            decimal p1,
    //            ushort q1,
    //            decimal p2,
    //            ushort q2,
    //            decimal expectedSubtotal
    //        )
    //        {
    //            var candidateOrder = new SubmitOrder(
    //                null,
    //                null,
    //                new LineItem(p1, new(), q1),
    //                new LineItem(p2, new(), q2)
    //            );

    //            var order = _builder.From(candidateOrder).Build().Value;

    //            order.Subtotal.Should().Be((Money)expectedSubtotal);
    //        }

    //        [Theory]
    //        [InlineData(0)]
    //        [InlineData(5)]
    //        public void ThenTipIsAssigned(decimal tip)
    //        {
    //            var candidateOrder = new SubmitOrder(null, tip);

    //            var order = _builder.From(candidateOrder).Build().Value;

    //            order.Tip.Should().Be((Money)tip);
    //        }

    //        [Theory]
    //        [InlineData(0)]
    //        [InlineData(0.99)]
    //        [InlineData(1)]
    //        public void ThenTotalIsSubtotalPlusTip(decimal tip)
    //        {
    //            var candidateOrder = new SubmitOrder(tip: tip);

    //            var order = _builder.From(candidateOrder).Build().Value;

    //            order.Total.Should().Be(order.Subtotal + tip);
    //        }

    //        #endregion
    //    }
    //}
}
