using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales.Services
{
    public record CustomerDto(string Email) : ICustomerBuilder
    {
        #region ICustomerBuilder Implementation

        public Email GetEmail() => Email;
        public Id GetId() => default;

        #endregion
    }
}
