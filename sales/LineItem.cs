using System.Collections.Generic;
using Jgs.Ddd;

namespace Shop.Sales
{
    public class LineItem : ValueObject
    {
        #region Creation

        public LineItem(decimal price, Id productId, ushort quantity)
        {
            Price = price;
            ProductId = productId;
            Quantity = quantity;
        }

        #endregion

        #region Public Interface

        public decimal Price { get; }
        public Id ProductId { get; }
        public ushort Quantity { get; }

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Price;
            yield return ProductId;
            yield return Quantity;
        }

        #endregion
    }
}
