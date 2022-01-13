using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Shop.Shared;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class GivenACanceledOrder : Context
    {
        #region Core

        private readonly Order _order;

        public GivenACanceledOrder()
        {
            _order = Order.From(
                CustomerId,
                CustomerIds,
                OrderStatus.Canceled
            ).Value;
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenApplyingPayment_ThenReturnInvalidOperationError()
        {
            var error = _order.ApplyPayment(1).Error;

            error.Should().Be(Error.InvalidOperation());
        }

        [Fact]
        public void WhenCanceled_ThenReturnInvalidOperationError()
        {
            var error = _order.Cancel().Error;

            error.Should().Be(Error.InvalidOperation());
        }

        [Fact]
        public void WhenConfirmed_ThenReturnInvalidOperationError()
        {
            var error = _order.Confirm().Error;

            error.Should().Be(Error.InvalidOperation());
        }

        #endregion

        public class WithOutstandingRefund : Context
        {
            #region Core

            private readonly Order _order;

            public WithOutstandingRefund()
            {
                _order = Order.From(
                    CustomerId,
                    CustomerIds,
                    OrderStatus.Canceled,
                    new Finances(paid: 25),
                    new LineItem(25, new Id(), 1)
                ).Value;
            }

            #endregion

            #region Test Methods

            [Fact]
            public void WhenRefunded_ThenOrderIsRefunded()
            {
                _order.IssueRefund();

                _order.Status.Should().Be(OrderStatus.Refunded);
            }

            #endregion
        }
    }
}
