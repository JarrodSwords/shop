using Jgs.Ddd;
using Shop.Catalog;

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

        public IVendorRepository Create(Shop.Catalog.Vendor vendor)
        {
            base.Create(vendor);
            return this;
        }

        public Shop.Catalog.Vendor Find(Id id) => base.Find(id);

        #endregion
    }
}
