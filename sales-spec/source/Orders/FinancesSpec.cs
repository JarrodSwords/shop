using FluentAssertions;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class FinancesSpec
    {
        public class WhenApplyingPayment
        {
            #region Core

            private Finances _finances = new(25, subtotal: 25);

            #endregion

            #region Test Methods

            [Theory]
            [InlineData(5, 20)]
            [InlineData(10, 15)]
            [InlineData(30, 0)]
            public void ThenDueIsDifferenceOfDueAndPaymentWithMinimumOfZero(decimal payment, decimal expected)
            {
                _finances = _finances.ApplyPayment(payment);

                _finances.Due.Should().Be((Money) expected);
            }

            [Theory]
            [InlineData(1, 1)]
            [InlineData(5, 2, 3)]
            public void ThenPaidIsUpdated(int expected, params int[] payments)
            {
                foreach (var p in payments)
                    _finances = _finances.ApplyPayment(p);

                _finances.Paid.Should().Be((Money) expected);
            }

            [Theory]
            [InlineData(30, 5)]
            [InlineData(32, 7)]
            public void WithMoreThanDue_ThenTipIsExcessPayment(decimal payment, decimal excess)
            {
                _finances = _finances.ApplyPayment(payment);

                _finances.Tip.Should().Be((Money) excess);
            }

            #endregion
        }
    }
}
