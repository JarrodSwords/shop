using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Catalog
{
    public partial class Vendor : Aggregate
    {
        public static readonly Vendor ManyLoves = new("Many Loves Charcuterie", "mlc");

        #region Creation

        private Vendor(
            Name name,
            Token skuToken,
            Id id = default
        ) : base(id)
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
