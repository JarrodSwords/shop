using Jgs.Ddd;
using Shop.Catalog;
using CatalogVendor = Shop.Catalog.Vendor;

namespace Shop.Write.Catalog
{
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        #region Creation

        public VendorRepository(Context context) : base(context)
        {
        }

        #endregion

        #region IVendorRepository Implementation

        public IVendorRepository Create(CatalogVendor vendor)
        {
            base.Create(vendor);
            return this;
        }

        public CatalogVendor Find(Id id) => base.Find(id);

        #endregion
    }
}
