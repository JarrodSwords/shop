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
            Abbreviation abbreviation,
            Name name,
            Description description = default
        )
        {
            Abbreviation = abbreviation;
            Description = description;
            Name = name;
        }

        #endregion

        #region Public Interface

        public Abbreviation Abbreviation { get; }
        public Description Description { get; }
        public Name Name { get; }

        #endregion
    }
}
