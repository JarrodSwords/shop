using Jgs.Ddd;
using Shop.Catalog;
using Shop.Shared;

namespace Shop.Write
{
    public partial class Vendor : IVendorBuilder
    {
        #region Creation

        private Vendor(Shop.Catalog.Vendor source) : base(source.Id)
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

        public static implicit operator Vendor(Shop.Catalog.Vendor source) => new(source);
        public static implicit operator Shop.Catalog.Vendor(Vendor source) => Shop.Catalog.Vendor.From(source).Value;

        #endregion
    }
}
