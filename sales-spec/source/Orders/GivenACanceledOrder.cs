using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class GivenACanceledOrder : Context
    {
        #region Core

        private readonly Order _order;

        public GivenACanceledOrder()
        {
            _order = Order.From(CustomerId, CustomerIds, OrderState.Canceled).Value;
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCanceling_ReturnOrderAlreadyCanceledError()
        {
            var result = _order.Cancel();

            result.Error.Should().Be(ErrorExtensions.OrderAlreadyCanceled());
        }

        #endregion
    }
}
