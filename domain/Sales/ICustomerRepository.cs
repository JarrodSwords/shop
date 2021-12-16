using Jgs.Ddd;

namespace Shop.Domain.Sales
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Id Create(Customer customer);
        bool Exists(Email email);
        Customer Find(Email email);
    }
}
