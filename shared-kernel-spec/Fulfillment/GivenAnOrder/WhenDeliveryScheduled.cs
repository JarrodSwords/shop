using System;
using FluentAssertions;
using Xunit;

namespace Shop.Shared.Fulfillment.GivenAnOrder
{
    public class WhenDeliveryScheduled
    {
        #region Core

        private readonly DateTime _deliveryTime = DateTime.Now;
        private readonly Order _order = ObjectProvider.CreateOrderPendingDelivery();

        public WhenDeliveryScheduled()
        {
            _order.ScheduleDelivery(_deliveryTime);
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ThenDeliveryIsScheduled()
        {
            _order.IsDeliveryScheduled.Should().BeTrue();
        }

        [Fact]
        public void ThenScheduledDeliveryIsSet()
        {
            _order.ScheduledDelivery.Should().Be(_deliveryTime);
        }

        #endregion
    }
}
