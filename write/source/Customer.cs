using System;
using Jgs.Ddd;
using Shop.Sales.Customers;
using Shop.Shared;
using DomainCustomer = Shop.Sales.Customers.Customer;

namespace Shop.Write
{
    public class Customer : Entity, ICustomerBuilder
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

        #region ICustomerBuilder Implementation

        public Email GetEmail() => Email;
        public Id GetId() => Id;

        #endregion

        #region Static Interface

        public static implicit operator Customer(DomainCustomer source) => new(source);
        public static implicit operator DomainCustomer(Customer source) => DomainCustomer.From(source.Email, source.Id);

        #endregion
    }
}
