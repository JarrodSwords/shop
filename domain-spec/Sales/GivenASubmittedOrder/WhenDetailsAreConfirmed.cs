using FluentAssertions;
using Shop.Domain.Sales;
using Xunit;

namespace Shop.Domain.Spec.Sales.GivenASubmittedOrder
{
    public class WhenDetailsAreConfirmed
    {
        #region Core

        private readonly Order _order = ObjectProvider.CreateSubmittedOrder();

        #endregion

        #region Test Methods

        [Fact]
        public void ThenOrderIsAwaitingPayment()
        {
            _order.ConfirmDetails();
            _order.IsAwaitingPayment.Should().BeTrue();
        }

        #endregion
    }
}
