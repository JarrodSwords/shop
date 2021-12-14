using System;
using Jgs.Ddd;

namespace Shop.Domain.Sales
{
    public class Order : Entity
    {
        #region Public Interface

        public DateTime? CancellationDate { get; private set; }
        public bool IsCancelled { get; private set; }

        public Order Cancel()
        {
            IsCancelled = true;
            CancellationDate = DateTime.Now;
            return this;
        }

        #endregion
    }
}
