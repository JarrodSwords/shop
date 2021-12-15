using System;
using Jgs.Cqrs;
using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Sales;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IQueryHandler<FindOrder, OrderDto> _findOrderHandler;
        private readonly ICommandHandler<SubmitOrder, Guid> _submitOrderHandler;

        #region Creation

        public SalesController(
            IQueryHandler<FindOrder, OrderDto> findOrderHandler,
            ICommandHandler<SubmitOrder, Guid> submitOrderHandler
        )
        {
            _findOrderHandler = findOrderHandler;
            _submitOrderHandler = submitOrderHandler;
        }

        #endregion

        #region Public Interface

        [HttpGet("{id:guid}")]
        public OrderDto FindOrder(Guid id) => _findOrderHandler.Handle(id);

        [HttpPost("submit-order")]
        public Guid SubmitOrder([FromBody] SubmitOrder command)
        {
            var id = _submitOrderHandler.Handle(command);
            return id;
        }

        #endregion
    }
}
