using Shop.Shared;

namespace Shop.Catalog
{
    public class ProductCategory
    {
        public static ProductCategory Box = new("BOX", "Box");
        public static ProductCategory Dessert = new("DES", "Dessert");
        public static ProductCategory Side = new("SID", "Side");

        #region Creation

        public ProductCategory(
            Name name,
            Token token,
            Description description = default
        )
        {
            Description = description;
            Name = name;
            Token = token;
        }

        #endregion

        #region Public Interface

        public Description Description { get; }
        public Name Name { get; }
        public Token Token { get; }

        #endregion
    }
}
