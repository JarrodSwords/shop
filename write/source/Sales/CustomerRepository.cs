using Shop.Sales.Customers;
using Shop.Shared;
using DomainCustomer = Shop.Sales.Customers.Customer;

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

        public ICustomerRepository Create(DomainCustomer customer)
        {
            base.Create(customer);
            return this;
        }

        public bool Exists(Email email) => Exists(x => x.Email == email);
        public DomainCustomer Find(Email email) => Find(x => x.Email == email);

        #endregion
    }
}
