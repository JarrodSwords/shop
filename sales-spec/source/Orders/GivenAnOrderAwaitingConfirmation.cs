using FluentAssertions;
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
                CustomerIds
            ).Value;
        }

        #endregion

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
            public void ThenAmountDueIsTotal()
            {
                Order.AmountDue.Should().Be(Order.Subtotal);
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
