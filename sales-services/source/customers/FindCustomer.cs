using Jgs.Cqrs;

namespace Shop.Sales.Services
{
    public record FindCustomer(string Email) : IQuery
    {
        #region Static Interface

        public static implicit operator FindCustomer(string source) => new(source);

        #endregion
    }

    public record CustomerDto(string Email);
}
