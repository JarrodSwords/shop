using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAPendingOrder
    {
        #region Core

        private readonly Order _order;

        public GivenAPendingOrder()
        {
            _order = OrderProvider.CreateOrder();
            _order.Add(new LineItem(25, new Id(), 1));
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenApplyingPayment_ThenReturnInvalidOperationError()
        {
            var error = _order.ApplyPayment(1).Error;

            error.Should().Be(InvalidOperation());
        }

        [Fact]
        public void WhenConfirmed_ThenReturnInvalidOperationError()
        {
            var error = _order.Confirm().Error;

            error.Should().Be(InvalidOperation());
        }

        [Fact]
        public void WhenRefundIssued_ThenReturnInvalidOperationError()
        {
            var error = _order.IssueRefund().Error;

            error.Should().Be(InvalidOperation());
        }

        [Fact]
        public void WhenSubmitted_ThenOrderIsAwaitingConfirmation()
        {
            _order.Submit();

            _order.Status.Should().Be(OrderStatus.AwaitingConfirmation);
        }

        #endregion
    }
}
