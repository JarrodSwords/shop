using Jgs.Ddd;

namespace Shop.Shared.Catalog
{
    public class Product : Entity
    {
        #region Creation

        public Product(
            Description description,
            Name name,
            Serves serves,
            Sku sku
        )
        {
            Description = description;
            Name = name;
            Serves = serves;
            Sku = sku;
        }

        #endregion

        #region Public Interface

        public Description Description { get; private set; }
        public Name Name { get; }
        public Serves Serves { get; }
        public Sku Sku { get; }

        public Product Update(Description description)
        {
            Description = description;
            return this;
        }

        #endregion
    }
}
