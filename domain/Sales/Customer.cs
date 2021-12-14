using Jgs.Ddd;

namespace Shop.Domain.Sales
{
    public class Customer : Entity
    {
        #region Creation

        public Customer(
            Email email,
            FirstName firstName,
            LastName lastName,
            Id id = default
        ) : base(id)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        #endregion

        #region Public Interface

        public Email Email { get; }
        public FirstName FirstName { get; }
        public LastName LastName { get; }

        #endregion
    }
}
