using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAPendingOrder_WithoutLineItems
    {
        #region Core

        private readonly Order _order = OrderProvider.CreateOrder();

        #endregion

        #region Test Methods

        [Fact]
        public void WhenSubmitted_ThenReturnInvalidOperationError()
        {
            var error = _order.Submit().Error;

            error.Should().Be(InvalidOperation());
        }

        #endregion
    }
}
