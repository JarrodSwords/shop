namespace Shop.Sales.Orders
{
    public interface IOrderBuilder
    {
        void CreateLineItems();
        void FindCustomer();
    }
}
