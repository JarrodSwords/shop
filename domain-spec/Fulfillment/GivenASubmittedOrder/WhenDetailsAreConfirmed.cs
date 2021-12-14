using FluentAssertions;
using Shop.Domain.Fulfillment;
using Shop.Domain.Spec.Catalog;
using Xunit;

namespace Shop.Domain.Spec.Fulfillment.GivenASubmittedOrder
{
    #region Test Methods

    public class WhenDetailsAreConfirmed
    {
        #region Core

        private readonly Order _order = ObjectProvider.SubmittedOrder;

        #endregion

        #region Test Methods

        [Fact]
        public void WhenDetailsAreConfirmed_ThenOrderIsAwaitingPayment()
        {
            _order.ConfirmDetails();
            _order.IsAwaitingPayment.Should().BeTrue();
        }

        #endregion
    }

    #endregion
}
