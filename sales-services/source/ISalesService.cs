using System;
using System.Collections.Generic;

namespace Shop.Sales.Services
{
    public interface ISalesService
    {
        IEnumerable<CustomerDto> FetchCustomers(FetchCustomers query);
        CustomerDto FindCustomer(FindCustomer query);
        OrderDto FindOrder(FindOrder query);
        ProductDto FindProduct(FindProduct query);
        Guid SubmitOrder(SubmitOrder command);
    }
}
