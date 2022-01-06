using Shop.Shared;
using CatalogVendor = Shop.Catalog.Vendor;

namespace Shop.Write
{
    public partial class Vendor
    {
        #region Creation

        private Vendor(CatalogVendor source) : base(source.Id)
        {
            Name = source.Name;
            SkuToken = source.SkuToken;
        }

        #endregion

        #region Static Interface

        public static implicit operator Vendor(CatalogVendor source) => new(source);

        public static implicit operator CatalogVendor(Vendor source) =>
            new CatalogVendor.Builder()
                .With(source.Id)
                .With((Name) source.Name)
                .With((Token) source.SkuToken)
                .Build().Value;

        #endregion
    }
}
