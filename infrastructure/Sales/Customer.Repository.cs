using Jgs.Ddd;
using Shop.Domain;
using Shop.Domain.Sales;
using DomainCustomer = Shop.Domain.Sales.Customer;

namespace Shop.Infrastructure.Sales
{
    public partial class Customer
    {
        internal class Repository : Repository<Customer>, ICustomerRepository
        {
            #region Creation

            public Repository(Context context) : base(context)
            {
            }

            #endregion

            #region ICustomerRepository Implementation

            public Id Create(DomainCustomer customer) => base.Create(customer);
            public bool Exists(Email email) => Exists(x => x.Email == email);
            public DomainCustomer Find(Email email) => Find(x => x.Email == email);

            #endregion
        }
    }
}
