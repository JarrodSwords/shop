using System;
using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Sales;

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

        [HttpGet("{id:guid}")]
        public OrderDto FindOrder(Guid id) => _salesService.FindOrder(id);

        [HttpPost("submit-order")]
        public Guid SubmitOrder([FromBody] SubmitOrder command) => _salesService.SubmitOrder(command);

        #endregion
    }
}
