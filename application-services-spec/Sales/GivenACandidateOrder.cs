using FluentAssertions;
using Shop.ApplicationServices.Sales;
using Xunit;

namespace Shop.ApplicationServices.Spec.Sales
{
    public class GivenACandidateOrder
    {
        #region Core

        private readonly FindOrder.Handler _findOrder = new();
        private readonly SubmitOrder _submitOrderCommand;
        private readonly SubmitOrder.Handler _submitOrderHandler;

        public GivenACandidateOrder()
        {
            _submitOrderCommand = new SubmitOrder(
                ObjectProvider.GetJohnDoe(),
                new OrderDetailsDto(LunchBoxes: 1)
            );

            _submitOrderHandler = new SubmitOrder.Handler(new UnitOfWork());
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenSubmitted_ThenAnOrderIsRecorded()
        {
            var orderId = _submitOrderHandler.Handle(_submitOrderCommand);
            var order = _findOrder.Handle(orderId);

            order.Should().NotBeNull();
        }

        #endregion
    }
}
