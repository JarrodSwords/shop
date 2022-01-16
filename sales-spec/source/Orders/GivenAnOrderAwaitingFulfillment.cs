using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Sales.Spec.ObjectProvider;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAnOrderAwaitingFulfillment
    {
        #region Core

        private readonly Order _order = CompletedOrder();

        #endregion

        #region Test Methods

        [Fact]
        public void WhenAddingALineItem_ThenReturnInvalidOperationError()
        {
            var error = _order.Add(CreateLunchBox()).Error;

            error.Should().Be(InvalidOperation);
        }

        [Fact]
        public void WhenApplyingPayment_ThenReturnInvalidOperationError()
        {
            var error = _order.ApplyPayment(1).Error;

            error.Should().Be(InvalidOperation);
        }

        [Fact]
        public void WhenCanceled_ThenOrderIsCanceled()
        {
            _order.Cancel();

            _order.Status.Should().HaveFlag(OrderStatus.Canceled);
        }

        [Fact]
        public void WhenConfirmed_ThenReturnInvalidOperationError()
        {
            var error = _order.Confirm().Error;

            error.Should().Be(InvalidOperation);
        }

        [Fact]
        public void WhenRefundIssued_ThenReturnInvalidOperationError()
        {
            var error = _order.IssueRefund().Error;

            error.Should().Be(InvalidOperation);
        }

        [Fact]
        public void WhenSubmitted_ThenReturnInvalidOperationError()
        {
            var error = _order.Submit().Error;

            error.Should().Be(InvalidOperation);
        }

        #endregion
    }
}
