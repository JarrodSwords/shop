using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAnOrderAwaitingPayment
    {
        #region Core

        private readonly Order _order;

        public GivenAnOrderAwaitingPayment()
        {
            _order = ObjectProvider.CreateOrderAwaitingConfirmation();
            _order.Confirm();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void When_CanceledThenOrderIsCanceled()
        {
            _order.Cancel();

            _order.Status.Should().Be(OrderStatus.Canceled);
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
        public void WhenConfirmed_ThenReturnInvalidOperationError()
        {
            var error = _order.Confirm().Error;

            error.Should().Be(InvalidOperation);
        }

        [Fact]
        public void WhenRefunded_ThenOrderIsRefunded()
        {
            _order.IssueRefund();

            _order.Status.Should().HaveFlag(OrderStatus.Refunded);
        }

        #endregion
    }
}
