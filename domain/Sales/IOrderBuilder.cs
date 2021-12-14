namespace Shop.Domain.Sales
{
    public interface IOrderBuilder
    {
        Customer GetCustomer();
        OrderDetails GetDetails();
    }
}
