using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;

namespace Shop.Sales.Spec.Orders
{
    public abstract class Context
    {
        protected readonly Id CustomerId;
        protected readonly List<Id> CustomerIds = new() { new Id() };

        #region Creation

        protected Context()
        {
            CustomerId = CustomerIds.First();
        }

        #endregion
    }
}
