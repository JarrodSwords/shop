using Microsoft.AspNetCore.Mvc;
using Shop.Sales.Services;

namespace Shop.Api.Sales
{
    [Route("api/sales/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISalesService _salesService;

        #region Creation

        public ProductsController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        #endregion

        #region Public Interface

        [HttpGet("{sku}")]
        public ActionResult<ProductDto> FindProduct(string sku) => _salesService.FindProduct(sku);

        [HttpPost]
        public ActionResult<string> RegisterProduct([FromBody] RegisterProduct command) =>
            _salesService.RegisterProduct(command);

        #endregion
    }
}
