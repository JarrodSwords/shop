using Jgs.Ddd;

namespace Shop.Domain.Catalog
{
    public class Product : Entity
    {
        #region Creation

        public Product(Name name, Serves serves)
        {
            Name = name;
            Serves = serves;
        }

        #endregion

        #region Public Interface

        public Name Name { get; }
        public Serves Serves { get; }

        #endregion
    }
}
