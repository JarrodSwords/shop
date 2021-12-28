using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;

namespace Shop.Catalog
{
    public partial class Company : Aggregate
    {
        public static readonly Company ManyLoves = new("Many Loves Charcuterie", "mlc");

        #region Creation

        public Company(ICompanyBuilder builder) : base(builder.GetId())
        {
            Name = builder.GetName();
            SkuToken = builder.GetSkuToken();
        }

        private Company(
            Name name,
            Token skuToken
        )
        {
            Name = name;
            SkuToken = skuToken;
        }

        public static Result<Company> From(ICompanyBuilder builder)
        {
            var company = new Company(builder);
            var validationResult = new Validator().Validate(company);

            return validationResult.IsValid
                ? Result.Success(company)
                : Result.Failure<Company>(validationResult.ToString());
        }

        #endregion

        #region Public Interface

        public Name Name { get; }
        public Token SkuToken { get; }

        #endregion
    }
}
