using Shop.Catalog;

namespace Shop.Write.Catalog
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private IProductRepository _products;
        private IVendorRepository _vendors;

        #region Creation

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Implementation

        public IProductRepository Products => _products ??= new ProductRepository(_context);

        public IVendorRepository Vendors => _vendors ??= new VendorRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
