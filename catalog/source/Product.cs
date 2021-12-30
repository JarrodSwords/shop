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
            var company = builder.GetCompany();

            Categories = builder.GetCategories();
            CompanyId = company?.Id;
            Description = builder.GetDescription();
            Name = builder.GetName();
            Size = builder.GetSize();

            Sku = CreateSku(
                company,
                Categories,
                builder.GetSkuToken(),
                Size
            );
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

        public ProductCategories Categories { get; }
        public Id CompanyId { get; }
        public Description Description { get; }
        public Name Name { get; }
        public Size Size { get; }
        public Sku Sku { get; }

        #endregion

        #region Static Interface

        private static Sku CreateSku(
            Company company,
            ProductCategories categories,
            Token product,
            Size size = default
        )
        {
            var sku = $"{company?.SkuToken}-{categories.GetToken()}-{product}";

            if (size != default)
                sku += $"-{(int) size:00}";

            return sku;
        }

        #endregion
    }
}
