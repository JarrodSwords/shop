using System;

namespace Shop.Infrastructure.Sales
{
    public class Customer : Entity
    {
        #region Creation

        public Customer(Guid id) : base(id)
        {
        }

        #endregion

        #region Public Interface

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #endregion
    }
}
