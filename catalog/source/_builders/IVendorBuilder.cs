using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Catalog
{
    public interface IVendorBuilder
    {
        Id GetId();
        Name GetName();
        Token GetSkuToken();
    }
}
