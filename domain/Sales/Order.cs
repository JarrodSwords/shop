using System;
using Jgs.Ddd;

namespace Shop.Domain.Sales
{
    public class Order : Entity
    {
        #region Creation

        public Order(OrderDetails details = default)
        {
            Details = details ?? OrderDetails.Default;
        }

        #endregion

        #region Public Interface

        public DateTime? CancellationDate { get; private set; }
        public OrderDetails Details { get; private set; }
        public bool IsAwaitingFulfillment { get; private set; }
        public bool IsAwaitingPayment { get; private set; }
        public bool IsCancelled { get; private set; }

        public Order Cancel()
        {
            IsCancelled = true;
            IsAwaitingFulfillment = false;
            IsAwaitingPayment = false;
            CancellationDate = DateTime.Now;
            return this;
        }

        public Order ConfirmDetails()
        {
            IsAwaitingPayment = true;
            return this;
        }

        public Order ConfirmPayment()
        {
            IsAwaitingFulfillment = true;
            IsAwaitingPayment = false;
            return this;
        }

        public Order Update(OrderDetails details)
        {
            Details = details;
            return this;
        }

        #endregion
    }
}
