using System.Collections.Generic;
using Jgs.Ddd;

namespace Shop.Sales
{
    public interface IOrderBuilder
    {
        Id GetCustomerId();
        IEnumerable<LineItem> GetLineItems();
    }
}
