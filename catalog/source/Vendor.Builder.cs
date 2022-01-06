using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;

namespace Shop.Catalog
{
    public partial class Vendor
    {
        public class Builder
        {
            private Id _id;
            private Name _name;
            private Token _skuToken;

            #region Public Interface

            public Result<Vendor> Build()
            {
                var vendor = new Vendor(_name, _skuToken, _id);
                var validationResult = new Validator().Validate(vendor);

                return validationResult.IsValid
                    ? Result.Success(vendor)
                    : Result.Failure<Vendor>(validationResult.ToString());
            }

            public Builder With(Id id)
            {
                _id = id;
                return this;
            }

            public Builder With(Name name)
            {
                _name = name;
                return this;
            }

            public Builder With(Token skuToken)
            {
                _skuToken = skuToken;
                return this;
            }

            #endregion
        }
    }
}
