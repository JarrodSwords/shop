using FluentAssertions;
using Shop.Domain.Sales;
using Shop.Domain.Spec.Catalog;
using Xunit;

namespace Shop.Domain.Spec.Sales.GivenASubmittedOrder
{
    public class WhenCancelled
    {
        #region Core

        private readonly Order Order = ObjectProvider.SubmittedOrder;

        public WhenCancelled()
        {
            Order.Cancel();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ThenCancellationDateIsSet()
        {
            Order.CancellationDate.Should().NotBeNull();
        }

        [Fact]
        public void ThenOrderIsCancelled()
        {
            Order.IsCancelled.Should().BeTrue();
        }

        #endregion
    }
}
