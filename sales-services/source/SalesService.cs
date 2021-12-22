using System;
using System.Collections.Generic;
using Jgs.Cqrs;

namespace Shop.Sales.Services
{
    public class SalesService : ISalesService
    {
        private readonly IQueryHandler<FetchCustomers, IEnumerable<CustomerDto>> _fetchCustomersHandler;
        private readonly IQueryHandler<FindCustomer, CustomerDto> _findCustomerHandler;
        private readonly IQueryHandler<FindOrder, OrderDto> _findOrderHandler;
        private readonly IQueryHandler<FindProduct, ProductDto> _findProductHandler;
        private readonly ICommandHandler<SubmitOrder, Guid> _submitOrderHandler;

        #region Creation

        public SalesService(
            IQueryHandler<FetchCustomers, IEnumerable<CustomerDto>> fetchCustomersHandler,
            IQueryHandler<FindCustomer, CustomerDto> findCustomerHandler,
            IQueryHandler<FindOrder, OrderDto> findOrderHandler,
            IQueryHandler<FindProduct, ProductDto> findProductHandler,
            ICommandHandler<SubmitOrder, Guid> submitOrderHandler
        )
        {
            _fetchCustomersHandler = fetchCustomersHandler;
            _findCustomerHandler = findCustomerHandler;
            _findOrderHandler = findOrderHandler;
            _findProductHandler = findProductHandler;
            _submitOrderHandler = submitOrderHandler;
        }

        #endregion

        #region ISalesService Implementation

        public IEnumerable<CustomerDto> FetchCustomers(FetchCustomers query) => _fetchCustomersHandler.Handle(query);

        public CustomerDto FindCustomer(FindCustomer query) => _findCustomerHandler.Handle(query);
        public OrderDto FindOrder(FindOrder query) => _findOrderHandler.Handle(query);
        public ProductDto FindProduct(FindProduct query) => _findProductHandler.Handle(query);
        public Guid SubmitOrder(SubmitOrder command) => _submitOrderHandler.Handle(command);

        #endregion
    }
}
