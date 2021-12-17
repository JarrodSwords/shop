using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales
{
    public class Customer : Aggregate
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

        private Customer(ICustomerBuilder builder) : this(
            builder.GetEmail(),
            builder.GetFirstName(),
            builder.GetLastName()
        )
        {
        }

        #endregion

        #region Public Interface

        public Email Email { get; }
        public FirstName FirstName { get; }
        public LastName LastName { get; }

        #endregion

        #region Static Interface

        public static Customer From(ICustomerBuilder builder) => new(builder);

        #endregion
    }

    public interface ICustomerBuilder
    {
        Email GetEmail();
        FirstName GetFirstName();
        LastName GetLastName();
    }
}
