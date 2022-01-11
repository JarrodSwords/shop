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

        [Fact]
        public void WhenConfirmed_ThenReturnInvalidOperationError()
        {
            var error = _order.Confirm().Error;

            error.Should().Be(Error.InvalidOperation());
        }

        #endregion
    }
}
