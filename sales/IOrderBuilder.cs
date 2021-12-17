using Jgs.Ddd;

namespace Shop.Sales
{
    public interface IOrderBuilder
    {
        Id GetCustomerId();
        OrderDetails GetDetails();
    }
}
