using System;
using DomainLineItem = Shop.Sales.Orders.Order.LineItemEntity;

namespace Shop.Write.Sales
{
    public class LineItem : Entity
    {
        #region Creation

        public LineItem(Guid id) : base(id)
        {
        }

        public LineItem(DomainLineItem source) : base(source.Id)
        {
            var (_, price, productId) = source.Value;

            OrderId = source.OrderId;
            Price = price;
            ProductId = productId;
        }

        public static LineItem From(DomainLineItem source) => new(source);

        #endregion

        #region Public Interface

        public Guid OrderId { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }

        public LineItem Update(LineItem source)
        {
            Price = source.Price;
            ProductId = source.ProductId;

            return this;
        }

        #endregion

        #region Static Interface

        public static implicit operator LineItem(DomainLineItem source) => new(source);

        #endregion
    }
}
