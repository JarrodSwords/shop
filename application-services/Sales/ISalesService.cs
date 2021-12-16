using System;

namespace Shop.ApplicationServices.Sales
{
    public interface ISalesService
    {
        public OrderDto FindOrder(FindOrder command);
        public Guid SubmitOrder(SubmitOrder command);
    }
}
