using System.Linq;
using FluentAssertions;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;
using static Shop.Sales.Spec.Orders.ObjectProvider;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public abstract class GivenAnOrderAwaitingConfirmation
    {
        public Order Order = CreateOrderAwaitingConfirmation();

        #region Private Interface

        private Money CalculateBalance() => Order.LineItems.Aggregate(Money.Zero, (current, x) => current += x.Total);

        #endregion

        public class WhenAddingALineItem : GivenAnOrderAwaitingConfirmation
        {
            #region Core

            public WhenAddingALineItem()
            {
                Order.Add(CreateLunchBox());
            }

            #endregion

            #region Test Methods

            [Fact]
            public void WhenAddingALineItem_ThenBalanceIsUpdated()
            {
                Order.Add(CreateLunchBox());

                var balance = CalculateBalance();

                Order.Finances.Balance.Should().Be(balance);
            }

            #endregion
        }

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
            public void WithFullPayment_ThenOrderIsSaleComplete()
            {
                Order.ApplyPayment(99);

                Order.Status.Should().Be(OrderStatus.SaleComplete);
            }

            [Fact]
            public void WithPartialPayment_ThenOrderIsConfirmed()
            {
                Order.ApplyPayment(5);

                Order.Status.Should().Be(OrderStatus.AwaitingPayment);
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
