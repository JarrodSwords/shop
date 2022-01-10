using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public abstract class State
        {
            protected Order Order;

            #region Public Interface

            public abstract Result<Error> Cancel();

            public void Set(Order order)
            {
                Order = order;
            }

            public void Set(OrderStates states)
            {
                Order.States = states;
            }

            #endregion
        }
    }
}
