using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Sales.Spec.ObjectProvider;
using static Shop.Sales.Spec.OrderHelper;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public abstract class GivenAnOrderAwaitingConfirmation
    {
        public Order Order = CreateOrderAwaitingConfirmation();

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
            public void WhenAddingALineItem_ThenFinancesAreUpdated()
            {
                Order.Add(CreateLunchBox());

                var balance = CalculateBalance(Order);

                Order.Finances.Balance.Should().Be(balance);
            }

            [Fact]
            public void WhenAddingALineItem_ThenLineItemsAreUpdated()
            {
                var count = Order.LineItems.Count;

                Order.Add(CreateLunchBox());

                Order.LineItems.Count.Should().Be(count + 1);
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
