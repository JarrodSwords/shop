using System.Collections.Generic;
using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public class LineItem : ValueObject
    {
        #region Creation

        public LineItem(
            Money price,
            Id productId,
            Quantity quantity,
            Options exclusions = default
        )
        {
            Exclusions = exclusions;
            Price = price;
            ProductId = productId;
            Quantity = quantity;
        }

        #endregion

        #region Public Interface

        public Options Exclusions { get; }
        public Money Price { get; }
        public Id ProductId { get; }
        public Quantity Quantity { get; }
        public Money Total => Price * Quantity;

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Exclusions;
            yield return Price;
            yield return ProductId;
            yield return Quantity;
        }

        #endregion
    }
}
