using Shop.Shared;

namespace Shop.Catalog
{
    public class ProductCategory
    {
        public static ProductCategory Box = new("Box", "box");
        public static ProductCategory Dessert = new("Dessert", "dst");
        public static ProductCategory Side = new("Side", "sid");

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
