using Jgs.Ddd;

namespace Shop.Domain.Sales
{
    public interface IOrderBuilder
    {
        Id GetCustomerId();
        OrderDetails GetDetails();
    }
}
