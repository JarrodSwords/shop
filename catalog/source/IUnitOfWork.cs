namespace Shop.Catalog
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        void Commit();
    }
}
