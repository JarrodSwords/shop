using System;

namespace Shop.Infrastructure.Sales
{
    public class Order : Entity
    {
        #region Creation

        public Order(Guid id) : base(id)
        {
        }

        #endregion

        #region Public Interface

        public Guid CustomerId { get; set; }

        #endregion
    }
}
