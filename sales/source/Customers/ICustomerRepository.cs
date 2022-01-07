using Shop.Shared;

namespace Shop.Sales.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        ICustomerRepository Create(Customer customer);
        bool Exists(Email email);
        Customer Find(Email email);
    }
}
