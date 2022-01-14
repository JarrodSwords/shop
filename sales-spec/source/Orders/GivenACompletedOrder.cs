using FluentAssertions;
using Shop.Sales.Orders;
using Xunit;
using static Shop.Shared.Error;

namespace Shop.Sales.Spec.Orders
{
    public class GivenACompletedOrder : Context
    {
        #region Core

        public GivenACompletedOrder()
        {
            Order = Order.From(
                CustomerId,
                CustomerIds,
                OrderStatus.SaleComplete
            ).Value;
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenApplyingPayment_ThenReturnInvalidOperationError()
        {
            var error = Order.ApplyPayment(1).Error;

            error.Should().Be(InvalidOperation());
        }

        [Fact]
        public void WhenConfirmed_ThenReturnInvalidOperationError()
        {
            var error = Order.Confirm().Error;

            error.Should().Be(InvalidOperation());
        }

        #endregion

        public class WhenCanceled : GivenACompletedOrder
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
                Order.Status.Should().HaveFlag(OrderStatus.Canceled);
            }

            #endregion
        }
    }
}
