using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;

namespace Shop.Sales
{
    public partial class Product : Aggregate
    {
        #region Creation

        private Product(IProductBuilder builder)
        {
            Description = builder.GetDescription();
            Name = builder.GetName();
            Price = builder.GetPrice();
            Sku = builder.GetSku();
        }

        public static Result<Product> From(IProductBuilder builder)
        {
            var product = new Product(builder);
            var validator = new Validator().Validate(product);

            return validator.IsValid
                ? Result.Success(product)
                : Result.Failure<Product>(validator.ToString());
        }

        #endregion

        #region Public Interface

        public Description Description { get; }
        public Name Name { get; }
        public Money Price { get; }
        public Sku Sku { get; }

        #endregion
    }
}
