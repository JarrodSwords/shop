using System;
using System.Collections.Generic;

namespace Shop.Sales.Services
{
    public interface ISalesService
    {
        IEnumerable<CustomerDto> FetchCustomers(FetchCustomers command);
        CustomerDto FindCustomer(FindCustomer command);
        OrderDto FindOrder(FindOrder command);
        ProductDto FindProduct(FindProduct command);
        string RegisterProduct(RegisterProduct command);
        Guid SubmitOrder(SubmitOrder command);
    }
}
