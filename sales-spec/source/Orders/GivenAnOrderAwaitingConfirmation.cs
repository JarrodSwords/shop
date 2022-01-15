using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public abstract class GivenAnOrderAwaitingConfirmation
    {
        public Order Order = OrderProvider.OrderAwaitingConfirmation();

        public class WhenApplyingPayment : GivenAnOrderAwaitingConfirmation
        {
            #region Test Methods

            [Fact]
            public void ThenFinancesAreUpdated()
            {
                Order.ApplyPayment(5);

                Order.Finances.Should().Be(new Finances(94, 5, 0, 99, 0));
            }

            [Fact]
            public void WithInsufficientAmount_ThenOrderIsConfirmed()
            {
                Order.ApplyPayment(5);

                Order.Status.Should().Be(OrderStatus.AwaitingPayment);
            }

            [Fact]
            public void WithSufficientAmount_ThenOrderIsSaleComplete()
            {
                Order.ApplyPayment(30);

                Order.Status.Should().Be(OrderStatus.SaleComplete);
            }

            #endregion
        }

        public class WhenCanceled : GivenAnOrderAwaitingConfirmation
        {
            #region Core

            public WhenCanceled()
            {
                Order.Cancel();
            }

            #endregion

            #region Test Methods

            [Fact]
            public void ThenOrderIsCanceled()
            {
                Order.Status.Should().Be(OrderStatus.Canceled);
            }

            #endregion
        }

        public class WhenConfirmed : GivenAnOrderAwaitingConfirmation
        {
            #region Core

            public WhenConfirmed()
            {
                Order.Confirm();
            }

            #endregion

            #region Test Methods

            [Fact]
            public void ThenBalanceIsSubtotal()
            {
                Order.Finances.Balance.Should().Be(Order.Finances.Subtotal);
            }

            [Fact]
            public void ThenOrderIsAwaitingPayment()
            {
                Order.Status.Should().Be(OrderStatus.AwaitingPayment);
            }

            #endregion
        }

        public class WhenRefunded : GivenAnOrderAwaitingConfirmation
        {
            #region Test Methods

            [Fact]
            public void ThenReturnInvalidOperationError()
            {
                var error = Order.IssueRefund().Error;

                error.Should().Be(InvalidOperation);
            }

            #endregion
        }
    }
}
