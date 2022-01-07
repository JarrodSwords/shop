using System;
using DomainCustomer = Shop.Sales.Customers.Customer;

namespace Shop.Write
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
        }

        #endregion

        #region Public Interface

        public string Email { get; set; }

        #endregion

        #region Static Interface

        public static implicit operator Customer(DomainCustomer source) => new(source);
        public static implicit operator DomainCustomer(Customer source) => DomainCustomer.From(source.Email, source.Id);

        #endregion
    }
}
