using FluentAssertions;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAnOrderAwaitingPayment : Context
    {
        #region Core

        private readonly Order _order;

        public GivenAnOrderAwaitingPayment()
        {
            _order = Order.From(
                CustomerId,
                CustomerIds,
                OrderState.AwaitingPayment
            ).Value;
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCanceled_ThenOrderIsCanceled()
        {
            _order.Cancel();

            _order.State.Should().Be(OrderState.Canceled);
        }

        #endregion
    }

    public class GivenACanceledOrder : Context
    {
        #region Core

        private readonly Order _order;

        public GivenACanceledOrder()
        {
            _order = Order.From(
                CustomerId,
                CustomerIds,
                OrderState.Canceled
            ).Value;
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCanceled_ThenReturnInvalidOperationError()
        {
            var result = _order.Cancel();

            result.Error.Should().Be(Error.InvalidOperation());
        }

        [Fact]
        public void WhenConfirmed_ThenReturnInvalidOperationError()
        {
            var result = _order.Cancel();

            result.Error.Should().Be(Error.InvalidOperation());
        }

        #endregion
    }
}
