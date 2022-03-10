using System.Collections.Generic;
using Jgs.Cqrs;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public record SubmitOrderWebsite(
        Email Email,
        IEnumerable<LineItemDto> LineItems
    ) : ICommand;
}
