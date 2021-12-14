using FluentAssertions;
using Shop.Domain.Sales;
using Xunit;

namespace Shop.Domain.Spec.Sales.GivenASubmittedOrder
{
    public class WhenDetailsAreUpdated
    {
        #region Core

        private readonly OrderDetails _details = new(1, isGift: true);
        private readonly Order _order = ObjectProvider.CreateSubmittedOrder();

        #endregion

        #region Test Methods

        [Fact]
        public void ThenDetailsAreUpdated()
        {
            _order.Update(_details);

            _order.Details.Should().Be(_details);
        }

        #endregion
    }
}
