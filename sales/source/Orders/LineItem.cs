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
            Options exclusions = default
        )
        {
            Exclusions = exclusions;
            Price = price;
            ProductId = productId;
        }

        #endregion

        #region Public Interface

        public Options Exclusions { get; }
        public Money Price { get; }
        public Id ProductId { get; }

        public override string ToString() =>
            $@"{nameof(ProductId)}: {ProductId}; 
{nameof(Price)}: {Price} 
{nameof(Exclusions)}: {Exclusions}";

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Exclusions;
            yield return Price;
            yield return ProductId;
        }

        #endregion
    }
}
