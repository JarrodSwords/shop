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
            private Id _companyId;
            private Description _description;
            private Id _id;
            private Name _name;
            private Size _size;
            private Sku _sku;

            #region Public Interface

            public Result<Product> Build()
            {
                var product = new Product(
                    _categories,
                    _companyId,
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

            public Builder With(Id companyId)
            {
                _companyId = companyId;
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

            public Director ConfigureNewProduct()
            {
                _builder
                    .FindCompany()
                    .GenerateSku();

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
