using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales
{
    public class Product : Aggregate
    {
        #region Creation

        public Product(
            Money price = default,
            Id id = default
        ) : base(id)
        {
            Price = price ?? Money.Zero;
        }

        #endregion

        #region Public Interface

        public Money Price { get; private set; }

        public Product Set(Money price)
        {
            Price = price;
            return this;
        }

        #endregion
    }
}
