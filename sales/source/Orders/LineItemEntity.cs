using Jgs.Ddd;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        private class LineItemEntity : Entity
        {
            #region Creation

            private LineItemEntity(LineItem lineItem, Id id = default) : base(id)
            {
                LineItem = lineItem;
            }

            #endregion

            #region Public Interface

            public LineItem LineItem { get; }

            #endregion

            #region Static Interface

            public static implicit operator LineItemEntity(LineItem source) => new(source);

            #endregion
        }
    }
}
