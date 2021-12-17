using FluentAssertions;
using Xunit;

namespace Shop.Sales.Spec.GivenASubmittedOrder
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
