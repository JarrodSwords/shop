using Microsoft.AspNetCore.Mvc;
using Shop.Sales.Services;

namespace Shop.Api.Sales
{
    [Route("api/sales/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ISalesService _salesService;

        #region Creation

        public CustomersController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        #endregion

        #region Public Interface

        [HttpGet("{email}")]
        public ActionResult<CustomerDto> FindCustomer(string email) => _salesService.FindCustomer(email);

        #endregion
    }
}
