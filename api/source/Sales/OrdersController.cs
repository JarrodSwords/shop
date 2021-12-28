using System;
using System.Collections.Generic;
using Jgs.Cqrs;
using Microsoft.AspNetCore.Mvc;
using Shop.Sales.Services;

namespace Shop.Api.Sales
{
    [Route("api/sales/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IQueryHandler<FindOrder, OrderDto> _findOrder;
        private readonly ICommandHandler<SubmitOrder, Guid> _submitOrder;

        #region Creation

        public OrdersController(
            IQueryHandler<FindOrder, OrderDto> findOrder,
            ICommandHandler<SubmitOrder, Guid> submitOrder
        )
        {
            _findOrder = findOrder;
            _submitOrder = submitOrder;
        }

        #endregion

        #region Public Interface

        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> FetchOrders() => new List<OrderDto>();

        [HttpGet("{id:guid}")]
        public ActionResult<OrderDto> FindOrder(Guid id) => _findOrder.Handle(id);

        [HttpPost]
        public ActionResult<Guid> SubmitOrder([FromBody] SubmitOrder command) => _submitOrder.Handle(command);

        #endregion
    }
}
