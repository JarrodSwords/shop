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
            Total = default;
        }

        #endregion

        #region Public Interface

        public Guid CustomerId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tip { get; set; }
        public decimal Total { get; set; }

        #endregion

        #region Static Interface

        public static implicit operator Order(DomainOrder source) => new(source);

        #endregion
    }
}
