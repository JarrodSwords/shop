using System;

namespace Shop.Write.Sales
{
    public class LineItem : Entity
    {
        #region Creation

        public LineItem(Guid id) : base(id)
        {
        }

        #endregion

        #region Public Interface

        public decimal Price { get; set; }
        public Guid ProductId { get; set; }

        #endregion
    }
}
