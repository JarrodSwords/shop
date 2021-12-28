namespace Shop.Catalog
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IProductRepository Products { get; }
        void Commit();
    }
}
