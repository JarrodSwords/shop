using Shop.Shared;

namespace Shop.Sales
{
    public interface IProductBuilder
    {
        Description GetDescription();
        Name GetName();
        Money GetPrice();
    }
}
