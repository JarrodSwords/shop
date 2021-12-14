using FluentAssertions;
using Shop.Domain.Sales;
using Shop.Domain.Spec.Catalog;
using Xunit;

namespace Shop.Domain.Spec.Sales
{
    public class GivenASubmittedOrder
    {
        #region Core

        private readonly Order _order = ObjectProvider.SubmittedOrder;

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCancelled_ThenOrderIsCancelled()
        {
            _order.Cancel();

            _order.IsCancelled.Should().BeTrue();
        }

        #endregion
    }
}
