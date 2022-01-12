using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAnOrderAwaitingConfirmation : Context
    {
        protected readonly Order Order;

        #region Creation

        public GivenAnOrderAwaitingConfirmation()
        {
            Order = Order.From(
                CustomerId,
                CustomerIds,
                default,
                new LineItem(25, new Id(), 1)
            ).Value;
        }

        #endregion

        public class WhenApplyingPayment : GivenAnOrderAwaitingConfirmation
        {
            #region Test Methods

            [Fact]
            public void ThenFinancesAreUpdated()
            {
                Order.ApplyPayment(5);

                Order.Finances.Should().Be(new Finances(20, 5, 25, 0));
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
                Order.State.Should().Be(OrderState.Canceled);
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
            public void ThenAmountDueIsSubtotal()
            {
                Order.Finances.Due.Should().Be(Order.Finances.Subtotal);
            }

            [Fact]
            public void ThenOrderIsAwaitingPayment()
            {
                Order.State.Should().Be(OrderState.AwaitingPayment);
            }

            #endregion
        }
    }
}
