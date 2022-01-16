using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Sales.Spec.ObjectProvider;
using static Shop.Sales.Spec.OrderHelper;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAnOrderAwaitingConfirmation
    {
        #region Core

        private readonly Order _order = CreateOrderAwaitingConfirmation();

        #endregion

        #region Test Methods

        [Fact]
        public void WhenAddingALineItem_ThenFinancesAreUpdated()
        {
            _order.Add(CreateLunchBox());

            var balance = CalculateBalance(_order);

            _order.Finances.Balance.Should().Be(balance);
        }

        [Fact]
        public void WhenAddingALineItem_ThenLineItemsAreUpdated()
        {
            var count = _order.LineItems.Count;

            _order.Add(CreateLunchBox());

            _order.LineItems.Count.Should().Be(count + 1);
        }

        [Fact]
        public void WhenApplyingPayment_ThenFinancesAreUpdated()
        {
            _order.ApplyPayment(110);

            _order.Finances.Should().Be(new Finances(0, 110, 0, 99, 11));
        }

        [Fact]
        public void WhenApplyingPayment_WithFullPayment_ThenOrderIsSaleComplete()
        {
            _order.ApplyPayment(99);

            _order.Status.Should().Be(OrderStatus.AwaitingFulfillment);
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
        public void WhenConfirmed_ThenOrderIsAwaitingPayment()
        {
            _order.Confirm();

            _order.Status.Should().Be(OrderStatus.AwaitingPayment);
        }

        [Fact]
        public void WhenRefundIssued_ThenReturnInvalidOperationError()
        {
            var error = _order.IssueRefund().Error;

            error.Should().Be(InvalidOperation);
        }

        [Fact]
        public void WhenRemovingALineItem_ThenFinancesAreUpdated()
        {
            _order.Remove(CreateLunchBox());

            var balance = CalculateBalance(_order);

            _order.Finances.Balance.Should().Be(balance);
        }

        [Fact]
        public void WhenRemovingALineItem_ThenLineItemsAreUpdated()
        {
            var count = _order.LineItems.Count;

            _order.Remove(CreateLunchBox());

            _order.LineItems.Count.Should().Be(count - 1);
        }

        [Fact]
        public void WhenRemovingALineItem_WithNoItemsLeft_ThenOrderIsCanceled()
        {
            _order.Remove(CreateLunchBox());
            _order.Remove(CreateLunchBox());
            _order.Remove(CreateCouplesBox());

            _order.Status.Should().Be(OrderStatus.Canceled);
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
