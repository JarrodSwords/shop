using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Catalog.Spec
{
    internal class ProductBuilder : IProductBuilder
    {
        private ProductCategories _categories;
        private Company _company;
        private Description _description;
        private Name _name;
        private Size _size;
        private Token _skuToken;

        #region Public Interface

        public Product Build() => Product.From(this).Value;

        public ProductBuilder With(ProductCategories categories)
        {
            _categories = categories;
            return this;
        }

        public ProductBuilder With(Company company)
        {
            _company = company;
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

        public ProductBuilder With(Size size)
        {
            _size = size;
            return this;
        }

        public ProductBuilder With(Token skuToken)
        {
            _skuToken = skuToken;
            return this;
        }

        #endregion

        #region IProductBuilder Implementation

        public ProductCategories GetCategories() => _categories;
        public Id GetCompanyId() => _company.Id;
        public Description GetDescription() => _description;
        public Name GetName() => _name;
        public Size GetSize() => _size;

        public Sku GetSku() =>
            Sku.Create(
                _company.SkuToken,
                _categories.GetToken(),
                _skuToken
            );

        #endregion
    }
}
