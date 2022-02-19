using Jgs.Ddd;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public class LineItemEntity : Entity
        {
            #region Creation

            private LineItemEntity(
                LineItem lineItem,
                Id orderId,
                Id id = default
            ) : base(id)
            {
                OrderId = orderId;
                Value = lineItem;
            }

            public static LineItemEntity From(LineItem value, Id orderId) => new(value, orderId);

            #endregion

            #region Public Interface

            public Id OrderId { get; }
            public LineItem Value { get; }

            #endregion
        }
    }
}
