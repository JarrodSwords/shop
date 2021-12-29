using Shop.Catalog;

namespace Shop.Write.Catalog
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private ICompanyRepository _companies;
        private IProductRepository _products;

        #region Creation

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Implementation

        public ICompanyRepository Companies => _companies ??= new CompanyRepository(_context);
        public IProductRepository Products => _products ??= new ProductRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
