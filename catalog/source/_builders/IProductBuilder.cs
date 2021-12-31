using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Catalog
{
    public interface IProductBuilder
    {
        ProductCategories GetCategories();
        Id GetCompanyId();
        Description GetDescription();
        Name GetName();
        Size GetSize();
        Sku GetSku();
    }
}
