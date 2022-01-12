using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAnOrderAwaitingPayment : Context
    {
        #region Core

        private readonly Order _order;

        public GivenAnOrderAwaitingPayment()
        {
            _order = Order.From(
                CustomerId,
                CustomerIds,
                default,
                new LineItem(25m, new Id(), 1)
            ).Value;

            _order.Confirm();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCanceled_ThenOrderIsCanceled()
        {
            _order.Cancel();

            _order.State.Should().Be(OrderState.Canceled);
        }

        [Fact]
        public void WhenConfirmed_ThenReturnInvalidOperationError()
        {
            var error = _order.Confirm().Error;

            error.Should().Be(Error.InvalidOperation());
        }

        [Fact]
        public void WhenPaymentReceived_ThenFinancesAreUpdated()
        {
            var expected = new Finances(0, 30, 25, 5);

            _order.ApplyPayment(30);

            _order.Finances.Should().Be(expected);
        }

        #endregion
    }
}
