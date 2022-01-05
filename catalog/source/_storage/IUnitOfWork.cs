namespace Shop.Catalog
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IVendorRepository Vendors { get; }
        void Commit();
    }
}
