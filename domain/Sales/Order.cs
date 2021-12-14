using Jgs.Ddd;

namespace Shop.Domain.Sales
{
    public class Order : Entity
    {
        #region Public Interface

        public bool IsCancelled { get; private set; }

        public Order Cancel()
        {
            IsCancelled = true;
            return this;
        }

        #endregion
    }
}
