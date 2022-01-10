using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders.State
{
    public abstract class OrderState
    {
        protected Order Order;

        #region Public Interface

        public abstract Result<Error> Cancel();
        public abstract OrderStates GetStates();

        public void Set(Order order)
        {
            Order = order;
        }

        #endregion
    }
}
