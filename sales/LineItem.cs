using System.Collections.Generic;
using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales
{
    public class LineItem : ValueObject
    {
        #region Creation

        public LineItem(Money price, Id productId, Quantity quantity)
        {
            Price = price;
            ProductId = productId;
            Quantity = quantity;
        }

        #endregion

        #region Public Interface

        public Money Price { get; }
        public Id ProductId { get; }
        public Quantity Quantity { get; }
        public Money Total => Price * Quantity;

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
