using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Jgs.Ddd;
using Shop.Sales.Orders;
using Xunit;

namespace Shop.Sales.Spec.Orders
{
    public class GivenAnOrderAwaitingConfirmation
    {
        #region Core

        private readonly Id _customerId;
        private readonly List<Id> _customerIds = new() { new Id() };

        private readonly Order _order;

        public GivenAnOrderAwaitingConfirmation()
        {
            _customerId = _customerIds.First();
            _order = Order.From(_customerId, _customerIds).Value;
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCancelingTheOrder_ThenStateIsCanceled()
        {
            _order.Cancel();

            _order.States.Should().Be(OrderStates.Canceled);
        }

        #endregion
    }
}
