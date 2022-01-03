using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;

namespace Shop.Catalog
{
    public partial class Vendor : Aggregate
    {
        public static readonly Vendor ManyLoves = new("Many Loves Charcuterie", "mlc");

        #region Creation

        public Vendor(IVendorBuilder builder) : base(builder.GetId())
        {
            Name = builder.GetName();
            SkuToken = builder.GetSkuToken();
        }

        private Vendor(
            Name name,
            Token skuToken
        )
        {
            Name = name;
            SkuToken = skuToken;
        }

        public static Result<Vendor> From(IVendorBuilder builder)
        {
            var vendor = new Vendor(builder);
            var validationResult = new Validator().Validate(vendor);

            return validationResult.IsValid
                ? Result.Success(vendor)
                : Result.Failure<Vendor>(validationResult.ToString());
        }

        #endregion

        #region Public Interface

        public Name Name { get; }
        public Token SkuToken { get; }

        #endregion
    }
}
