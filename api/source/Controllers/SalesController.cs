using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Sales.Services;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        #region Creation

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        #endregion

        #region Public Interface

        [HttpGet("orders")]
        public ActionResult<IEnumerable<OrderDto>> FetchOrders() => new List<OrderDto>();

        [HttpGet("orders/{id:guid}")]
        public ActionResult<OrderDto> FindOrder(Guid id) => _salesService.FindOrder(id);

        [HttpPost("orders")]
        public ActionResult<Guid> SubmitOrder([FromBody] SubmitOrder command) => _salesService.SubmitOrder(command);

        #endregion
    }
}
