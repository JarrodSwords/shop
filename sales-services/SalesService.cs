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
        private readonly ICommandHandler<SubmitOrder, Guid> _submitOrderHandler;

        #region Creation

        public SalesService(
            IQueryHandler<FetchCustomers, IEnumerable<CustomerDto>> fetchCustomersHandler,
            IQueryHandler<FindCustomer, CustomerDto> findCustomerHandler,
            IQueryHandler<FindOrder, OrderDto> findOrderHandler,
            ICommandHandler<SubmitOrder, Guid> submitOrderHandler
        )
        {
            _fetchCustomersHandler = fetchCustomersHandler;
            _findCustomerHandler = findCustomerHandler;
            _findOrderHandler = findOrderHandler;
            _submitOrderHandler = submitOrderHandler;
        }

        #endregion

        #region ISalesService Implementation

        public IEnumerable<CustomerDto> FetchCustomers(FetchCustomers command) =>
            _fetchCustomersHandler.Handle(command);

        public CustomerDto FindCustomer(FindCustomer command) => _findCustomerHandler.Handle(command);
        public OrderDto FindOrder(FindOrder command) => _findOrderHandler.Handle(command);
        public Guid SubmitOrder(SubmitOrder command) => _submitOrderHandler.Handle(command);

        #endregion
    }
}
