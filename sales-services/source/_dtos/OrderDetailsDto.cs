namespace Shop.Sales.Services
{
    public record OrderDetailsDto(
        ushort Baguettes = default,
        ushort CouplesBoxes = default,
        ushort DessertBoxes = default,
        ushort FamilyBoxes = default,
        bool IsGift = default,
        bool IsSpecialOccasion = default,
        ushort LunchBoxes = default,
        ushort PartyBoxes = default,
        ushort Strawberries = default
    );
}
