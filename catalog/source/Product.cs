using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;

namespace Shop.Catalog
{
    public partial class Product : Aggregate
    {
        #region Creation

        private Product(IProductBuilder builder)
        {
            Category = builder.GetCategory();
            Description = builder.GetDescription();
            Name = builder.GetName();
            Size = builder.GetSize();
            Sku = CreateSku(builder.GetCompany(), Category, builder.GetSkuToken());
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

        public ProductCategory Category { get; }
        public Description Description { get; }
        public Name Name { get; }
        public Size Size { get; }
        public Sku Sku { get; }

        #endregion

        #region Static Interface

        private static Sku CreateSku(
            Company company,
            ProductCategory category,
            Token product
        ) =>
            $"{company?.SkuToken}-{category?.SkuToken}-{product}".ToLower();

        #endregion
    }
}
