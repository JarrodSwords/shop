using System;
using DomainCustomer = Shop.Sales.Customer;

namespace Shop.Infrastructure
{
    public class Customer : Entity
    {
        #region Creation

        public Customer(Guid id) : base(id)
        {
        }

        public Customer(DomainCustomer source) : this(source.Id)
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

        public static implicit operator Customer(DomainCustomer source) => new(source);

        public static implicit operator DomainCustomer(Customer source) =>
            new(
                source.Email,
                source.FirstName,
                source.LastName,
                source.Id
            );

        #endregion
    }
}
