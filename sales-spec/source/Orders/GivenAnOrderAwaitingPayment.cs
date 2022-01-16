using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Sales.Spec.ObjectProvider;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAnOrderAwaitingPayment
    {
        #region Core

        private readonly Order _order;

        public GivenAnOrderAwaitingPayment()
        {
            _order = CreateOrderAwaitingConfirmation();
            _order.Confirm();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenAddingALineItem_ThenReturnInvalidOperationError()
        {
            var error = _order.Add(CreateLunchBox()).Error;

            error.Should().Be(InvalidOperation);
        }

        [Fact]
        public void WhenApplyingPayment_ThenFinancesAreUpdated()
        {
            var expected = new Finances(69, 30, 0, 99, 0);

            _order.ApplyPayment(30);

            _order.Finances.Should().Be(expected);
        }

        [Fact]
        public void WhenApplyingPayment_WithFullPayment_ThenOrderIsSaleComplete()
        {
            _order.ApplyPayment(99);

            _order.Status.Should().Be(OrderStatus.SaleComplete);
        }

        [Fact]
        public void WhenApplyingPayment_WithPartialPayment_ThenOrderIsAwaitingPayment()
        {
            _order.ApplyPayment(5);

            _order.Status.Should().Be(OrderStatus.AwaitingPayment);
        }

        [Fact]
        public void WhenCanceled_ThenOrderIsCanceled()
        {
            _order.Cancel();

            _order.Status.Should().Be(OrderStatus.Canceled);
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

        #endregion
    }
}
