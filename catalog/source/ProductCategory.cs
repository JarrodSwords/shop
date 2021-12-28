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
            Token skuToken
        )
        {
            Name = name;
            SkuToken = skuToken;
        }

        #endregion

        #region Public Interface

        public Name Name { get; }
        public Token SkuToken { get; }

        #endregion
    }
}
