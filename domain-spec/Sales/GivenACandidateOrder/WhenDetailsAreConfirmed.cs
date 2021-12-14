using FluentAssertions;
using Shop.Domain.Sales;
using Shop.Domain.Spec.Catalog;
using Xunit;

namespace Shop.Domain.Spec.Sales.GivenACandidateOrder
{
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
}
