using System;

namespace Shop.Infrastructure.Sales
{
    public class Customer : Entity
    {
        #region Creation

        public Customer(Guid id) : base(id)
        {
        }

        public Customer(Domain.Sales.Customer source) : this(source.Id)
        {
            Email = source.Email;
            FirstName = source.FirstName;
            LastName = source.LastName;
        }

        #endregion

        #region Public Interface

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #endregion

        #region Static Interface

        public static implicit operator Customer(Domain.Sales.Customer source) => new(source);

        #endregion
    }
}
