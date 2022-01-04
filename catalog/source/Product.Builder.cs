using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;

namespace Shop.Catalog
{
    public partial class Product
    {
        public class Builder
        {
            private ProductCategories _categories;
            private Description _description;
            private Id _id;
            private Name _name;
            private Size _size;
            private Sku _sku;
            private Id _vendorId;

            #region Public Interface

            public Result<Product> Build()
            {
                var product = new Product(
                    _categories,
                    _vendorId,
                    _name,
                    _size,
                    _sku,
                    _description,
                    _id
                );

                var validator = new Validator().Validate(product);

                return validator.IsValid
                    ? Result.Success(product)
                    : Result.Failure<Product>(validator.ToString());
            }

            public Builder With(ProductCategories categories)
            {
                _categories = categories;
                return this;
            }

            public Builder With(Description description)
            {
                _description = description;
                return this;
            }

            public Builder With(Name name)
            {
                _name = name;
                return this;
            }

            public Builder With(Size size)
            {
                _size = size;
                return this;
            }

            public Builder With(Sku sku)
            {
                _sku = sku;
                return this;
            }

            public Builder With(Id vendorId)
            {
                _vendorId = vendorId;
                return this;
            }

            public Builder WithId(Id id)
            {
                _id = id;
                return this;
            }

            #endregion
        }

        public class Director
        {
            private IProductBuilder _builder;

            #region Public Interface

            public Director ConfigureRegisterProduct()
            {
                _builder.FindVendor();
                _builder.GenerateSku();

                return this;
            }

            public Director ConfigureSeedProduct()
            {
                _builder.GenerateSku();

                return this;
            }

            public Director With(IProductBuilder builder)
            {
                _builder = builder;
                return this;
            }

            #endregion
        }
    }
}
