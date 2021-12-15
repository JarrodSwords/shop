using Shop.Domain.Sales;

namespace Shop.Infrastructure.Sales
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private IOrderRepository _orders;

        #region Creation

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Implementation

        public IOrderRepository Orders => _orders ??= new OrderRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
