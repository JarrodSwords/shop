using System.Linq;
using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public abstract class GivenAPendingOrder
    {
        #region Core

        protected Order Order;

        #endregion

        #region Private Interface

        private Money CalculateBalance() => Order.LineItems.Aggregate(Money.Zero, (current, x) => current += x.Total);

        #endregion

        #region Test Methods

        [Fact]
        public void ThenBalanceIsSumOfLineItems()
        {
            var balance = CalculateBalance();

            Order.Finances.Balance.Should().Be(balance);
        }

        [Fact]
        public void WhenAddingALineItem_ThenBalanceIsUpdated()
        {
            Order.Add(new(25, new Id(), 1));

            var balance = CalculateBalance();

            Order.Finances.Balance.Should().Be(balance);
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

            Order.Status.Should().Be(OrderStatus.Canceled);
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

        public class WithLineItems : GivenAPendingOrder
        {
            #region Core

            public WithLineItems()
            {
                Order = OrderProvider.PendingOrder();
                Order.Add(new(25, new Id(), 1));
            }

            #endregion

            #region Test Methods

            [Fact]
            public void WhenSubmitted_ThenOrderIsAwaitingConfirmation()
            {
                Order.Submit();

                Order.Status.Should().Be(OrderStatus.AwaitingConfirmation);
            }

            #endregion
        }

        public class WithoutLineItems : GivenAPendingOrder
        {
            #region Core

            public WithoutLineItems()
            {
                Order = OrderProvider.PendingOrder();
            }

            #endregion

            #region Test Methods

            [Fact]
            public void WhenSubmitted_ThenReturnInvalidOperationError()
            {
                var error = Order.Submit().Error;

                error.Should().Be(InvalidOperation);
            }

            #endregion
        }
    }
}
