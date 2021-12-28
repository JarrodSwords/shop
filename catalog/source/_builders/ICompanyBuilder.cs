using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Catalog
{
    public interface ICompanyBuilder
    {
        Id GetId();
        Name GetName();
        Token GetSkuToken();
    }
}
