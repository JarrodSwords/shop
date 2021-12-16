using System;
using Shop.Domain.Sales;

namespace Shop.ApplicationServices.Spec.Sales
{
    public class UnitOfWork : IUnitOfWork
    {
        private IOrderRepository _orders;

        #region IUnitOfWork Implementation

        public ICustomerRepository Customers => null;
        public IOrderRepository Orders => _orders ??= new OrderRepository();

        public void Commit()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
