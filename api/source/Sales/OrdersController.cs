using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Sales.Services;

namespace Shop.Api.Sales
{
    [Route("api/sales/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ISalesService _salesService;

        #region Creation

        public OrdersController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        #endregion

        #region Public Interface

        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> FetchOrders() => new List<OrderDto>();

        [HttpGet("{id:guid}")]
        public ActionResult<OrderDto> FindOrder(Guid id) => _salesService.FindOrder(id);

        [HttpPost]
        public ActionResult<Guid> SubmitOrder([FromBody] SubmitOrder command) => _salesService.SubmitOrder(command);

        #endregion
    }
}
