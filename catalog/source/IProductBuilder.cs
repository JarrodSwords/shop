using Shop.Shared;

namespace Shop.Catalog
{
    public interface IProductBuilder
    {
        Description GetDescription();
        Name GetName();
        Money GetPrice();
    }
}
