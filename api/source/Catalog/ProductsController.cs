using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Services;

namespace Shop.Api.Catalog
{
    [Route("api/catalog/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        #region Creation

        public ProductsController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        #endregion

        #region Public Interface

        [HttpGet("{recordName}", Name = "FindProduct")]
        public ActionResult<ProductDto> FindProduct(string recordName) => _catalogService.FindProduct(recordName);

        [HttpPost]
        public ActionResult<ProductDto> RegisterProduct([FromBody] RegisterProduct command)
        {
            var product = _catalogService.RegisterProduct(command);
            return CreatedAtRoute(
                nameof(FindProduct),
                new { product.RecordName },
                product
            );
        }

        #endregion
    }
}
