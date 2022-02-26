using Jgs.Cqrs;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public record SubmitOrder(
        Email Email,
        Options Exclusions = default,
        ushort Baguettes = default,
        ushort CouplesBoxes = default,
        ushort DessertBoxes = default,
        ushort FamilyBoxes = default,
        ushort LunchBoxes = default,
        ushort PartyBoxes = default,
        ushort Strawberries = default,
        decimal Tip = default
    ) : ICommand
    {
    }
}
