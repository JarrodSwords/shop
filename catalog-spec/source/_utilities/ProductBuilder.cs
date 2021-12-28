using Shop.Shared;

namespace Shop.Catalog.Spec
{
    internal class ProductBuilder : IProductBuilder
    {
        private ProductCategory _category;
        private Company _company;
        private Description _description;
        private Name _name;
        private Size _size;
        private Token _skuToken;

        #region Public Interface

        public Product Build() => Product.From(this).Value;

        public ProductBuilder With(ProductCategory category)
        {
            _category = category;
            return this;
        }

        public ProductBuilder With(Description description)
        {
            _description = description;
            return this;
        }

        public ProductBuilder With(Name name)
        {
            _name = name;
            return this;
        }

        public ProductBuilder With(Company company)
        {
            _company = company;
            return this;
        }

        public ProductBuilder With(Token skuToken)
        {
            _skuToken = skuToken;
            return this;
        }

        public ProductBuilder With(Size size)
        {
            _size = size;
            return this;
        }

        #endregion

        #region IProductBuilder Implementation

        public ProductCategory GetCategory() => _category;
        public Company GetCompany() => _company;
        public Description GetDescription() => _description;
        public Name GetName() => _name;
        public Size GetSize() => _size;
        public Token GetSkuToken() => _skuToken;

        #endregion
    }
}
