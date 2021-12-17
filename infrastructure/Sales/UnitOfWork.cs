using Shop.Sales;

namespace Shop.Write.Sales
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private ICustomerRepository _customers;
        private IOrderRepository _orders;

        #region Creation

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Implementation

        public ICustomerRepository Customers => _customers ??= new CustomerRepository(_context);
        public IOrderRepository Orders => _orders ??= new OrderRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
