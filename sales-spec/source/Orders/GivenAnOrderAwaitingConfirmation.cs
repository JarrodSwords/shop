using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAnOrderAwaitingConfirmation : Context
    {
        #region Core

        private readonly Order _order;

        public GivenAnOrderAwaitingConfirmation()
        {
            _order = Order.From(
                CustomerId,
                CustomerIds
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
        public void WhenConfirmed_ThenOrderIsAwaitingPayment()
        {
            _order.Confirm();

            _order.State.Should().Be(OrderState.AwaitingPayment);
        }

        #endregion
    }
}
