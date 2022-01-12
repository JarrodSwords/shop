using FluentAssertions;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class GivenACompletedOrder : Context
    {
        #region Core

        private readonly Order _order;

        public GivenACompletedOrder()
        {
            _order = Order.From(
                CustomerId,
                CustomerIds,
                OrderState.SaleComplete
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

        [Fact]
        public void WhenRefunded_ThenOrderIsRefunded()
        {
            _order.Refund();

            _order.State.Should().Be(OrderState.Refunded);
        }

        #endregion
    }
}
