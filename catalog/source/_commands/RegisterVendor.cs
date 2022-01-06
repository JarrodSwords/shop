using Jgs.Cqrs;
using Shop.Shared;

namespace Shop.Catalog
{
    public record RegisterVendor(
        Name Name,
        Token SkuToken
    ) : ICommand;
}
