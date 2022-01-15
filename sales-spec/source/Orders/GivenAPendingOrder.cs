using FluentAssertions;
using Xunit;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAPendingOrder
    {
        #region Test Methods

        [Fact]
        public void WhenSubmitted_WithoutLineItems_ThenReturnInvalidOperationError()
        {
            var order = OrderProvider.CreateOrder();

            var error = order.Submit().Error;

            error.Should().Be(InvalidOperation());
        }

        #endregion
    }
}
