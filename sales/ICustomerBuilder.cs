using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales
{
    public interface ICustomerBuilder
    {
        Email GetEmail();
        FirstName GetFirstName();
        Id GetId();
        LastName GetLastName();
    }
}
