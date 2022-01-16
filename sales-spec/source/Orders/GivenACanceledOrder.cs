using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Sales.Spec.ObjectProvider;
using static Shop.Shared.Error;
using static Shop.Shared.Money;

namespace Shop.Sales.Spec.Orders
{
    public abstract class GivenACanceledOrder
    {
        #region Core

        protected Order Order;

        #endregion

        #region Test Methods

        [Fact]
        public void ThenBalanceIsZero()
        {
            Order.Finances.Balance.Should().Be(Zero);
        }

        [Fact]
        public void WhenApplyingPayment_ThenReturnInvalidOperationError()
        {
            var error = Order.ApplyPayment(1).Error;

            error.Should().Be(InvalidOperation);
        }

        [Fact]
        public void WhenCanceled_ThenReturnInvalidOperationError()
        {
            var error = Order.Cancel().Error;

            error.Should().Be(InvalidOperation);
        }

        [Fact]
        public void WhenConfirmed_ThenReturnInvalidOperationError()
        {
            var error = Order.Confirm().Error;

            error.Should().Be(InvalidOperation);
        }

        #endregion

        public class WithoutRefundDue : GivenACanceledOrder
        {
            #region Core

            public WithoutRefundDue()
            {
                Order = CreateOrderAwaitingConfirmation();
                Order.Cancel();
            }

            #endregion

            #region Test Methods

            [Fact]
            public void WhenRefundIssued_ThenReturnInvalidOperationError()
            {
                var error = Order.IssueRefund().Error;

                error.Should().Be(InvalidOperation);
            }

            #endregion
        }

        public class WithRefundDue : GivenACanceledOrder
        {
            #region Core

            public WithRefundDue()
            {
                Order = CreateOrderAwaitingConfirmation();
                Order.ApplyPayment(20);
                Order.Cancel();
            }

            #endregion

            #region Test Methods

            [Fact]
            public void WhenRefundIssued_ThenFinancesAreUpdated()
            {
                Order.IssueRefund();

                Order.Finances.Refunded.Should().Be(Order.Finances.Paid);
            }

            [Fact]
            public void WhenRefundIssued_ThenOrderIsRefunded()
            {
                Order.IssueRefund();

                Order.Status.Should().Be(OrderStatus.Refunded);
            }

            #endregion
        }
    }
}
