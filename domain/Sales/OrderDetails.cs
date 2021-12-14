using System.Collections.Generic;
using Jgs.Ddd;

namespace Shop.Domain.Sales
{
    public class OrderDetails : ValueObject
    {
        public static OrderDetails Default = new();

        #region Creation

        public OrderDetails(
            ushort couplesBoxes = default,
            ushort dessertBoxes = default,
            ushort familyBoxes = default,
            bool isGift = default,
            bool isSpecialOccasion = default,
            ushort lunchBoxes = default,
            ushort partyBoxes = default
        )
        {
            CouplesBoxes = couplesBoxes;
            DessertBoxes = dessertBoxes;
            FamilyBoxes = familyBoxes;
            IsGift = isGift;
            IsSpecialOccasion = isSpecialOccasion;
            LunchBoxes = lunchBoxes;
            PartyBoxes = partyBoxes;
        }

        #endregion

        #region Public Interface

        public ushort CouplesBoxes { get; }
        public ushort DessertBoxes { get; }
        public ushort FamilyBoxes { get; }
        public bool IsGift { get; }
        public bool IsSpecialOccasion { get; }
        public ushort LunchBoxes { get; }
        public ushort PartyBoxes { get; }

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return CouplesBoxes;
            yield return DessertBoxes;
            yield return FamilyBoxes;
            yield return IsGift;
            yield return IsSpecialOccasion;
            yield return LunchBoxes;
            yield return PartyBoxes;
        }

        #endregion
    }
}
