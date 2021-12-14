using System;
using Jgs.Ddd;

namespace Shop.Domain.Fulfillment
{
    public class Order : Entity
    {
        #region Public Interface

        public bool IsDeliveryScheduled => ScheduledDelivery is not null;
        public DateTime? ScheduledDelivery { get; private set; }

        public Order ScheduleDelivery(DateTime deliveryTime)
        {
            ScheduledDelivery = deliveryTime;
            return this;
        }

        #endregion
    }
}
