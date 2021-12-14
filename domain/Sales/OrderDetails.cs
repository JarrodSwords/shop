using System.Collections.Generic;
using Jgs.Ddd;

namespace Shop.Domain.Sales
{
    public class OrderDetails : ValueObject
    {
        public static OrderDetails Default = new();

        #region Creation

        public OrderDetails(bool isGift = default, bool isSpecialOccasion = default)
        {
            IsGift = isGift;
            IsSpecialOccasion = isSpecialOccasion;
        }

        #endregion

        #region Public Interface

        public bool IsGift { get; }
        public bool IsSpecialOccasion { get; }

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return IsGift;
            yield return IsSpecialOccasion;
        }

        #endregion
    }
}
