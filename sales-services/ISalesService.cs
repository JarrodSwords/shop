using System;

namespace Shop.Sales.Services
{
    public interface ISalesService
    {
        CustomerDto FindCustomer(FindCustomer command);
        public OrderDto FindOrder(FindOrder command);
        public Guid SubmitOrder(SubmitOrder command);
    }
}
