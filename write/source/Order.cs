using System;
using DomainOrder = Shop.Sales.Orders.Order;

namespace Shop.Write
{
    public class Order : Entity
    {
        #region Creation

        public Order(Guid id) : base(id)
        {
        }

        public Order(DomainOrder order) : base(order.Id)
        {
            CustomerId = order.CustomerId;
            Subtotal = order.Finances.Subtotal;
            Tip = order.Finances.Tip;
        }

        #endregion

        #region Public Interface

        public decimal Balance { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsAwaitingConfirmation { get; set; }
        public bool IsAwaitingFulfillment { get; set; }
        public bool IsAwaitingPayment { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsPending { get; set; }
        public bool IsRefundDue { get; set; }
        public bool IsRefunded { get; set; }
        public decimal Paid { get; set; }
        public decimal Refunded { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tip { get; set; }

        #endregion

        #region Static Interface

        public static implicit operator Order(DomainOrder source) => new(source);

        #endregion
    }
}
