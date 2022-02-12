using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Sales.Orders;
using DomainOrder = Shop.Sales.Orders.Order;
using DomainLineItem = Shop.Sales.Orders.Order.LineItemEntity;
using LineItem = Shop.Write.Sales.LineItem;

namespace Shop.Write
{
    public class Order : Entity
    {
        #region Creation

        public Order(Guid id) : base(id)
        {
        }

        public Order(DomainOrder source) : base(source.Id)
        {
            CustomerId = source.CustomerId;
            LineItems = new List<LineItem>();

            Update(source.Finances);
            Update(source.LineItemEntities);
            Update(source.Status);
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
        public List<LineItem> LineItems { get; set; }
        public decimal Paid { get; set; }
        public decimal Refunded { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tip { get; set; }

        #endregion

        #region Private Interface

        private void Update(Finances finances)
        {
            var (balance, paid, refunded, subtotal, tip) = finances;

            Balance = balance;
            Paid = paid;
            Refunded = refunded;
            Subtotal = subtotal;
            Tip = tip;
        }

        private void Update(IEnumerable<DomainLineItem> lineItems)
        {
            var targetItems = lineItems.Select(LineItem.From).ToList();

            foreach (var deletedItem in LineItems.Except(targetItems))
                LineItems.Remove(deletedItem);

            foreach (var item in LineItems)
                item.Update(targetItems.Single(x => x.Id == item.Id));

            foreach (var newItem in targetItems.Except(LineItems))
                LineItems.Add(newItem);
        }

        private void Update(OrderStatus status)
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
