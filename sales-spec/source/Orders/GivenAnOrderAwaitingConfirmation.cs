using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Shop.Shared;
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
                OrderStatus.AwaitingConfirmation,
                lineItems: new LineItem(25, new Id(), 1)
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

                _order.Finances.Should().Be(new Finances(20, 5, 0, 25, 0));
            }

            [Fact]
            public void WithInsufficientAmount_ThenOrderIsConfirmed()
            {
                _order.ApplyPayment(5);

                _order.Status.Should().Be(OrderStatus.AwaitingPayment);
            }

            [Fact]
            public void WithSufficientAmount_ThenOrderIsSaleComplete()
            {
                _order.ApplyPayment(30);

                _order.Status.Should().Be(OrderStatus.SaleComplete);
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
                _order.Status.Should().Be(OrderStatus.Canceled);
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
            public void ThenBalanceIsSubtotal()
            {
                _order.Finances.Balance.Should().Be(_order.Finances.Subtotal);
            }

            [Fact]
            public void ThenOrderIsAwaitingPayment()
            {
                _order.Status.Should().Be(OrderStatus.AwaitingPayment);
            }

            #endregion
        }

        public class WhenRefunded : GivenAnOrderAwaitingConfirmation
        {
            #region Test Methods

            [Fact]
            public void ThenReturnInvalidOperationError()
            {
                var error = _order.IssueRefund().Error;

                error.Should().Be(Error.InvalidOperation());
            }

            #endregion
        }
    }
}
