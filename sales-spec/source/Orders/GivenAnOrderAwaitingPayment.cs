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

        [Theory]
        [InlineData(1, 24)]
        [InlineData(20, 5)]
        public void WhenPaymentReceived_ThenAmountDueIsAmountDueMinusAmountPaid(decimal paid, decimal due)
        {
            _order.ApplyPayment(paid);

            _order.AmountDue.Should().Be((Money) due);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 2, 3)]
        public void WhenPaymentReceived_ThenAmountPaidIsUpdated(int expected, params int[] payments)
        {
            foreach (var p in payments)
                _order.ApplyPayment(p);

            _order.AmountPaid.Should().Be((Money) expected);
        }

        #endregion
    }
}
