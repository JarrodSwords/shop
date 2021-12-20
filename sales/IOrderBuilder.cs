using System.Collections.Generic;
using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales
{
    public interface IOrderBuilder
    {
        Id GetCustomerId();
        IEnumerable<LineItem> GetLineItems();
        Money GetSubtotal();
    }
}
