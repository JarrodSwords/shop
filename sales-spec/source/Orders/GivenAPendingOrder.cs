using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
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
