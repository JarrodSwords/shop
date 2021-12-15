using System;
using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Sales;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly FindOrder.Handler _findOrderHandler;
        private readonly SubmitOrder.Handler _submitOrderHandler;

        #region Creation

        public SalesController(
            FindOrder.Handler findOrderHandler,
            SubmitOrder.Handler submitOrderHandler
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
