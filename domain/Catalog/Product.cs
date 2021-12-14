using Jgs.Ddd;

namespace Shop.Domain.Catalog
{
    public class Product : Entity
    {
        #region Creation

        public Product(Name name, Serves serves, Sku sku)
        {
            Name = name;
            Serves = serves;
            Sku = sku;
        }

        #endregion

        #region Public Interface

        public Name Name { get; }
        public Serves Serves { get; }
        public Sku Sku { get; }

        #endregion
    }
}
