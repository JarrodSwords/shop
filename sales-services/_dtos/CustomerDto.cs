using Shop.Shared;

namespace Shop.Sales.Services
{
    public record CustomerDto(
        string Email,
        string FirstName,
        string LastName
    ) : ICustomerBuilder
    {
        #region ICustomerBuilder Implementation

        public Email GetEmail() => Email;
        public FirstName GetFirstName() => FirstName;
        public LastName GetLastName() => LastName;

        #endregion
    }
}
