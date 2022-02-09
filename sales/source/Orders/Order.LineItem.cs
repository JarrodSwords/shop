using Jgs.Ddd;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        private class LineItem : Entity
        {
            #region Creation

            private LineItem(Orders.LineItem lineItem, Id id = default) : base(id)
            {
                Value = lineItem;
            }

            #endregion

            #region Public Interface

            public Orders.LineItem Value { get; }

            #endregion

            #region Static Interface

            public static implicit operator LineItem(Orders.LineItem source) => new(source);

            #endregion
        }
    }
}
