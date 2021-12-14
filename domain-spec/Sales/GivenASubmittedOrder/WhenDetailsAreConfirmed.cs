using FluentAssertions;
using Shop.Domain.Sales;
using Shop.Domain.Spec.Catalog;
using Xunit;

namespace Shop.Domain.Spec.Sales.GivenASubmittedOrder
{
    #region Test Methods

    public class WhenDetailsAreConfirmed
    {
        #region Core

        private readonly Order Order = ObjectProvider.SubmittedOrder;

        #endregion

        #region Test Methods

        [Fact]
        public void WhenDetailsAreConfirmed_ThenOrderIsAwaitingPayment()
        {
            Order.ConfirmDetails();
            Order.IsAwaitingPayment.Should().BeTrue();
        }

        #endregion
    }

    #endregion
}
