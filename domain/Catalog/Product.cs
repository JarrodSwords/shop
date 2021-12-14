using Jgs.Ddd;

namespace Shop.Domain.Catalog
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

        public Description Description { get; }
        public Name Name { get; }
        public Serves Serves { get; }
        public Sku Sku { get; }

        #endregion
    }
}
