using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales.Customers
{
    public class Customer : Aggregate
    {
        #region Creation

        private Customer(Email email, Id id = default) : base(id)
        {
            Email = email;
        }

        public static Customer From(Email email, Id id = default) => new(email);

        #endregion

        #region Public Interface

        public Email Email { get; }

        #endregion
    }
}
