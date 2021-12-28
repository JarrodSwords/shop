using Shop.Shared;

namespace Shop.Catalog
{
    public interface IProductBuilder
    {
        ProductCategory GetCategory();
        Company GetCompany();
        Description GetDescription();
        Name GetName();
        Size GetSize();
        Token GetSkuToken();
    }
}
