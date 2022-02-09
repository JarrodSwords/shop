using System;
using DomainLineItem = Shop.Sales.Orders.LineItem;

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
            Price = source.Price;
            ProductId = source.ProductId;
        }

        #endregion

        #region Public Interface

        public Guid OrderId { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }

        #endregion

        #region Static Interface

        public static implicit operator LineItem(DomainLineItem source) => new(source);

        #endregion
    }
}
