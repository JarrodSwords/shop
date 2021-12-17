using System;
using Jgs.Cqrs;

namespace Shop.Sales.Services
{
    public class SalesService : ISalesService
    {
        private readonly IQueryHandler<FindOrder, OrderDto> _findOrderHandler;
        private readonly ICommandHandler<SubmitOrder, Guid> _submitOrderHandler;

        #region Creation

        public SalesService(
            IQueryHandler<FindOrder, OrderDto> findOrderHandler,
            ICommandHandler<SubmitOrder, Guid> submitOrderHandler
        )
        {
            _findOrderHandler = findOrderHandler;
            _submitOrderHandler = submitOrderHandler;
        }

        #endregion

        #region ISalesService Implementation

        public OrderDto FindOrder(FindOrder command) => _findOrderHandler.Handle(command);
        public Guid SubmitOrder(SubmitOrder command) => _submitOrderHandler.Handle(command);

        #endregion
    }
}
