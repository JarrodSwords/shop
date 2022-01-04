using Jgs.Ddd;

namespace Shop.Catalog
{
    public interface IVendorRepository
    {
        IVendorRepository Create(Vendor vendor);
        Vendor Find(Id id);
    }
}
