using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales.Products
{
    public class Product : Aggregate
    {
        #region Creation

        public Product(
            ProductCategories categories = default,
            Money price = default,
            Sku sku = default,
            Id id = default
        ) : base(id)
        {
            Price = price ?? Money.Zero;
            Categories = categories;
            Sku = sku;
        }

        #endregion

        #region Public Interface

        public ProductCategories Categories { get; }
        public Money Price { get; private set; }
        public Sku Sku { get; set; }

        public Product Set(Money price)
        {
            Price = price;
            return this;
        }

        #endregion
    }
}
