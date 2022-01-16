using System;
using Shop.Sales.Orders;
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
            UpdateFinances(order.Finances);
            UpdateStatus(order.Status);
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

        #region Private Interface

        private void UpdateFinances(Finances finances)
        {
            var (balance, paid, refunded, subtotal, tip) = finances;

            Balance = balance;
            Paid = paid;
            Refunded = refunded;
            Subtotal = subtotal;
            Tip = tip;
        }

        private void UpdateStatus(OrderStatus status)
        {
            IsAwaitingConfirmation = status.HasFlag(OrderStatus.AwaitingConfirmation);
            IsAwaitingFulfillment = status.HasFlag(OrderStatus.AwaitingFulfillment);
            IsAwaitingPayment = status.HasFlag(OrderStatus.AwaitingPayment);
            IsCanceled = status.HasFlag(OrderStatus.Canceled);
            IsPending = status.HasFlag(OrderStatus.Pending);
            IsRefundDue = status.HasFlag(OrderStatus.RefundDue);
            IsRefunded = status.HasFlag(OrderStatus.Refunded);
        }

        #endregion

        #region Static Interface

        public static implicit operator Order(DomainOrder source) => new(source);

        #endregion
    }
}
