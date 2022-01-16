using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Sales.Spec.ObjectProvider;
using static Shop.Sales.Spec.OrderHelper;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public abstract class GivenAPendingOrder
    {
        #region Core

        protected Order Order;

        #endregion

        #region Test Methods

        [Fact]
        public void ThenBalanceIsSumOfLineItems()
        {
            var balance = CalculateBalance(Order);

            Order.Finances.Balance.Should().Be(balance);
        }

        [Fact]
        public void WhenAddingALineItem_ThenFinancesAreUpdated()
        {
            Order.Add(LunchBox);

            var balance = CalculateBalance(Order);

            Order.Finances.Balance.Should().Be(balance);
        }

        [Fact]
        public void WhenAddingALineItem_ThenLineItemsAreUpdated()
        {
            var count = Order.LineItems.Count;

            Order.Add(LunchBox);

            Order.LineItems.Count.Should().Be(count + 1);
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
                Order = CreatePendingOrder();
                Order.Add(LunchBox);
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
                Order = CreatePendingOrder();
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
