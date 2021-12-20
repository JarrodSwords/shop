using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Id Create(Customer customer);
        bool Exists(Email email);
        Customer Find(Email email);
    }
}
