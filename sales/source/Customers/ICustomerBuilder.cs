using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales.Customers
{
    public interface ICustomerBuilder
    {
        Email GetEmail();
        Id GetId();
    }
}
