using Jgs.Ddd;
using Shop.Infrastructure;
using Shop.Shared;
using DomainCustomer = Shop.Sales.Customer;

namespace Shop.Sales.Infrastructure
{
    public class Customer
    {
        public class Repository : Shop.Infrastructure.IRepository<Customer>, ICustomerRepository
        {
            #region Creation

            public Repository(Context context) : base(context)
            {
            }

            #endregion

            #region ICustomerRepository Implementation

            public Id Create(DomainCustomer customer) => Create(customer);

            public bool Exists(Email email) => Exists(x => x.Email == email);
            public DomainCustomer Find(Email email) => Find(x => x.Email == email);

            #endregion
        }
    }
}
