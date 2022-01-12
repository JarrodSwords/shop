using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAnOrderAwaitingConfirmation : Context
    {
        private readonly Order _order;

        #region Creation

        public GivenAnOrderAwaitingConfirmation()
        {
            _order = Order.From(
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
                _order.ApplyPayment(5);

                _order.Finances.Should().Be(new Finances(20, 5, 25, 0));
            }

            [Fact]
            public void WithInsufficientAmount_ThenOrderIsConfirmed()
            {
                _order.ApplyPayment(5);

                _order.State.Should().Be(OrderState.AwaitingPayment);
            }

            [Fact]
            public void WithSufficientAmount_ThenOrderIsAwaitingFulfillment()
            {
                _order.ApplyPayment(30);

                _order.State.Should().Be(OrderState.SaleComplete);
            }

            #endregion
        }

        public class WhenCanceled : GivenAnOrderAwaitingConfirmation
        {
            #region Core

            public WhenCanceled()
            {
                _order.Cancel();
            }

            #endregion

            #region Test Methods

            [Fact]
            public void ThenOrderIsCanceled()
            {
                _order.State.Should().Be(OrderState.Canceled);
            }

            #endregion
        }

        public class WhenConfirmed : GivenAnOrderAwaitingConfirmation
        {
            #region Core

            public WhenConfirmed()
            {
                _order.Confirm();
            }

            #endregion

            #region Test Methods

            [Fact]
            public void ThenAmountDueIsSubtotal()
            {
                _order.Finances.Due.Should().Be(_order.Finances.Subtotal);
            }

            [Fact]
            public void ThenOrderIsAwaitingPayment()
            {
                _order.State.Should().Be(OrderState.AwaitingPayment);
            }

            #endregion
        }
    }
}
