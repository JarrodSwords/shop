using Shop.Shared;

namespace Shop.Catalog
{
    public interface IProductBuilder
    {
        ProductCategories GetCategories();
        Company GetCompany();
        Description GetDescription();
        Name GetName();
        Size GetSize();
        Token GetSkuToken();
    }
}
