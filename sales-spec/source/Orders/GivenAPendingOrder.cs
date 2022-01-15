using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAPendingOrder_WithoutLineItems
    {
        #region Test Methods

        [Fact]
        public void WhenSubmitted_ThenReturnInvalidOperationError()
        {
            var order = OrderProvider.CreateOrder();

            var error = order.Submit().Error;

            error.Should().Be(InvalidOperation());
        }

        #endregion
    }

    public class GivenAPendingOrder
    {
        #region Test Methods

        [Fact]
        public void WhenSubmitted_ThenOrderIsAwaitingConfirmation()
        {
            var order = OrderProvider.CreateOrder();
            order.Add(new LineItem(25, new Id(), 1));

            order.Submit();

            order.Status.Should().Be(OrderStatus.AwaitingConfirmation);
        }

        #endregion
    }
}
