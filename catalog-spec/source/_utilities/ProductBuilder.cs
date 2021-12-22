using Shop.Shared;

namespace Shop.Catalog.Spec
{
    internal class ProductBuilder : IProductBuilder
    {
        private ProductCategory _category;
        private Description _description;
        private Name _name;
        private Money _price;
        private Size _size;

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

        public ProductBuilder With(Money price)
        {
            _price = price;
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
        public Description GetDescription() => _description;
        public Name GetName() => _name;
        public Money GetPrice() => _price;
        public Size GetSize() => _size;

        #endregion
    }
}
