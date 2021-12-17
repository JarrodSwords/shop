using System;

namespace Shop.Sales.Services
{
    public interface ISalesService
    {
        public OrderDto FindOrder(FindOrder command);
        public Guid SubmitOrder(SubmitOrder command);
    }
}
