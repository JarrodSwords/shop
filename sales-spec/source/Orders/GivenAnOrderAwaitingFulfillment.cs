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

        protected Order Order;

        public GivenAnOrderAwaitingFulfillment()
        {
            Order = CompletedOrder();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenAddingALineItem_ThenReturnInvalidOperationError()
        {
            var error = Order.Add(CreateLunchBox()).Error;

            error.Should().Be(InvalidOperation);
        }

        [Fact]
        public void WhenApplyingPayment_ThenReturnInvalidOperationError()
        {
            var error = Order.ApplyPayment(1).Error;

            error.Should().Be(InvalidOperation);
        }

        [Fact]
        public void WhenCanceled_ThenOrderIsCanceled()
        {
            Order.Cancel();

            Order.Status.Should().HaveFlag(OrderStatus.Canceled);
        }

        [Fact]
        public void WhenConfirmed_ThenReturnInvalidOperationError()
        {
            var error = Order.Confirm().Error;

            error.Should().Be(InvalidOperation);
        }

        [Fact]
        public void WhenRefundIssued_ThenReturnInvalidOperationError()
        {
            var error = Order.IssueRefund().Error;

            error.Should().Be(InvalidOperation);
        }

        #endregion
    }
}
