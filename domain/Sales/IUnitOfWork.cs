namespace Shop.Domain.Sales
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        void Commit();
    }
}
