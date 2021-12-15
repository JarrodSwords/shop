namespace Shop.Domain.Sales
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }
        void Commit();
    }
}
