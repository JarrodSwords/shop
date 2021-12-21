using Shop.Shared;

namespace Shop.Sales.Spec
{
    internal class ProductBuilder : IProductBuilder
    {
        private Description _description;
        private Name _name;
        private Money _price;

        #region Public Interface

        public Product Build() => Product.From(this).Value;

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

        #endregion

        #region IProductBuilder Implementation

        public Description GetDescription() => _description;
        public Name GetName() => _name;
        public Money GetPrice() => _price;

        #endregion
    }
}
