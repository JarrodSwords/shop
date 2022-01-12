using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public abstract class GivenAnOrderAwaitingPayment : Context
    {
        #region Creation

        protected GivenAnOrderAwaitingPayment()
        {
            Order = Order.From(
                CustomerId,
                CustomerIds,
                OrderState.AwaitingPayment,
                new LineItem(25m, new Id(), 1)
            ).Value;

            Order.Confirm();
        }

        #endregion

        public class WhenApplyingPayment : GivenAnOrderAwaitingPayment
        {
            #region Test Methods

            [Fact]
            public void ThenFinancesAreUpdated()
            {
                var expected = new Finances(0, 30, 0, 25, 5);

                Order.ApplyPayment(30);

                Order.Finances.Should().Be(expected);
            }

            [Fact]
            public void WithInsufficientAmount_ThenOrderIsAwaitingPayment()
            {
                Order.ApplyPayment(5);

                Order.State.Should().Be(OrderState.AwaitingPayment);
            }

            [Fact]
            public void WithSufficientAmount_ThenOrderIsSaleComplete()
            {
                Order.ApplyPayment(30);

                Order.State.Should().Be(OrderState.SaleComplete);
            }

            #endregion
        }

        public class WhenCanceled : GivenAnOrderAwaitingPayment
        {
            #region Test Methods

            [Fact]
            public void ThenOrderIsCanceled()
            {
                Order.Cancel();

                Order.State.Should().Be(OrderState.Canceled);
            }

            #endregion
        }

        public class WhenConfirmed : GivenAnOrderAwaitingPayment
        {
            #region Test Methods

            [Fact]
            public void ThenReturnInvalidOperationError()
            {
                var error = Order.Confirm().Error;

                error.Should().Be(Error.InvalidOperation());
            }

            #endregion
        }

        public class WhenRefunded : GivenAnOrderAwaitingPayment
        {
            #region Test Methods

            [Fact]
            public void ThenOrderIsRefunded()
            {
                Order.IssueRefund();

                Order.State.Should().HaveFlag(OrderState.Refunded);
            }

            #endregion
        }
    }
}
