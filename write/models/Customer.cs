using System;
using Jgs.Ddd;
using Shop.Sales;
using Shop.Shared;
using DomainCustomer = Shop.Sales.Customer;

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
            FirstName = source.FirstName;
            LastName = source.LastName;
        }

        #endregion

        #region Public Interface

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #endregion

        #region ICustomerBuilder Implementation

        public Email GetEmail() => Email;
        public FirstName GetFirstName() => FirstName;
        public Id GetId() => Id;
        public LastName GetLastName() => LastName;

        #endregion

        #region Static Interface

        public static implicit operator Customer(DomainCustomer source) => new(source);
        public static implicit operator DomainCustomer(Customer source) => DomainCustomer.From(source);

        #endregion
    }
}
