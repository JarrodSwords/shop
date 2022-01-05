using Jgs.Ddd;
using Shop.Catalog;
using Shop.Shared;
using CatalogVendor = Shop.Catalog.Vendor;

namespace Shop.Write
{
    public partial class Vendor : IVendorBuilder
    {
        #region Creation

        private Vendor(CatalogVendor source) : base(source.Id)
        {
            Name = source.Name;
            SkuToken = source.SkuToken;
        }

        #endregion

        #region IVendorBuilder Implementation

        public Id GetId() => Id;
        public Name GetName() => Name;
        public Token GetSkuToken() => SkuToken;

        #endregion

        #region Static Interface

        public static implicit operator Vendor(CatalogVendor source) => new(source);
        public static implicit operator CatalogVendor(Vendor source) => CatalogVendor.From(source).Value;

        #endregion
    }
}
