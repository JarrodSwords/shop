using System;

namespace Shop.Sales.Services
{
    public record OrderDto(
        Guid Id,
        string Email,
        int LunchBoxes,
        int CouplesBoxes,
        int FamilyBoxes,
        int PartyBoxes,
        int DessertBoxes,
        int Baguettes,
        int Strawberries,
        bool IsGift,
        bool IsSpecialOccasion
    );
}
