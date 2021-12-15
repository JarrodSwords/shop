using Shop.Domain.Sales;

namespace Shop.Infrastructure.Sales
{
    public class UnitOfWork : IUnitOfWork
    {
        private IOrderRepository _orders;

        #region IUnitOfWork Implementation

        public IOrderRepository Orders => null;

        #endregion
    }
}
