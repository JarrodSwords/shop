using Jgs.Ddd;

namespace Shop.Domain.Catalog
{
    public class Product : Entity
    {
        #region Creation

        public Product(Name name)
        {
            Name = name;
        }

        #endregion

        #region Public Interface

        public Name Name { get; }

        #endregion
    }
}
