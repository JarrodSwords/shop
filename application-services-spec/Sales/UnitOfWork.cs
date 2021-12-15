using Shop.Domain.Sales;

namespace Shop.ApplicationServices.Spec.Sales
{
    public class UnitOfWork : IUnitOfWork
    {
        private IOrderRepository _orders;

        #region IUnitOfWork Implementation

        public IOrderRepository Orders => _orders ??= new OrderRepository();

        #endregion
    }
}
