using Jgs.Cqrs;
using Shop.Shared;

namespace Shop.Sales.Products
{
    public record SetPrice(Money Price, Sku Sku) : ICommand;
}
