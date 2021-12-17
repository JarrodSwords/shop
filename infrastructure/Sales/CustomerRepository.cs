using Jgs.Ddd;
using Shop.Sales;
using Shop.Shared;
using DomainCustomer = Shop.Sales.Customer;

namespace Shop.Write.Sales
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        #region Creation

        public CustomerRepository(Context context) : base(context)
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
