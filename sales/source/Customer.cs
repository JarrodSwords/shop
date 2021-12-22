using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales
{
    public class Customer : Aggregate
    {
        #region Creation

        private Customer(ICustomerBuilder builder) : base(builder.GetId())
        {
            Email = builder.GetEmail();
        }

        public static Customer From(ICustomerBuilder builder) => new(builder);

        #endregion

        #region Public Interface

        public Email Email { get; }

        #endregion
    }
}
