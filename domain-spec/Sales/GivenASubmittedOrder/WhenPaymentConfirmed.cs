using FluentAssertions;
using Shop.Domain.Sales;
using Xunit;

namespace Shop.Domain.Spec.Sales.GivenASubmittedOrder
{
    public class WhenPaymentConfirmed
    {
        #region Core

        private readonly Order _order = ObjectProvider.SubmittedOrder;

        public WhenPaymentConfirmed()
        {
            _order.ConfirmPayment();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ThenOrderIsAwaitingFulfillment()
        {
            _order.IsAwaitingFulfillment.Should().BeTrue();
        }

        [Fact]
        public void ThenOrderIsNotAwaitingPayment()
        {
            _order.IsAwaitingPayment.Should().BeFalse();
        }

        #endregion
    }
}
