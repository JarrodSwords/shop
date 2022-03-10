using Shop.Shared;

namespace Shop.Sales.Orders
{
    public record LineItemDto(
        Sku Sku,
        Options Exclusions = Options.None
    );
}
