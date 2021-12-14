using Jgs.Ddd;

namespace Shop.Domain.Sales
{
    public class Product : Entity
    {
        #region Creation

        public Product(Sku sku, Money price = default)
        {
            Sku = sku;
            Price = price ?? Money.Zero;
        }

        #endregion

        #region Public Interface

        public Money Price { get; private set; }
        public Sku Sku { get; }

        public Product Set(Money price)
        {
            Price = price;
            return this;
        }

        #endregion
    }
}
