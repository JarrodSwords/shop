using System.Collections.Generic;
using Jgs.Ddd;

namespace Shop.Domain.Sales
{
    public class OrderDetails : ValueObject
    {
        public static OrderDetails Default = new();

        #region Creation

        public OrderDetails(
            ushort baguettes = default,
            ushort couplesBoxes = default,
            ushort dessertBoxes = default,
            ushort familyBoxes = default,
            bool isGift = default,
            bool isSpecialOccasion = default,
            ushort lunchBoxes = default,
            ushort partyBoxes = default,
            ushort strawberries = default
        )
        {
            Baguettes = baguettes;
            CouplesBoxes = couplesBoxes;
            DessertBoxes = dessertBoxes;
            FamilyBoxes = familyBoxes;
            IsGift = isGift;
            IsSpecialOccasion = isSpecialOccasion;
            LunchBoxes = lunchBoxes;
            PartyBoxes = partyBoxes;
            Strawberries = strawberries;
        }

        #endregion

        #region Public Interface

        public ushort Baguettes { get; }
        public ushort CouplesBoxes { get; }
        public ushort DessertBoxes { get; }
        public ushort FamilyBoxes { get; }
        public bool IsGift { get; }
        public bool IsSpecialOccasion { get; }
        public ushort LunchBoxes { get; }
        public ushort PartyBoxes { get; }
        public ushort Strawberries { get; }

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Baguettes;
            yield return CouplesBoxes;
            yield return DessertBoxes;
            yield return FamilyBoxes;
            yield return IsGift;
            yield return IsSpecialOccasion;
            yield return LunchBoxes;
            yield return PartyBoxes;
            yield return Strawberries;
        }

        #endregion
    }
}
