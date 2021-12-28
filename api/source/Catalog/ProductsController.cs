using Jgs.Cqrs;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Services;

namespace Shop.Api.Catalog
{
    [Route("api/catalog/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IQueryHandler<FindProduct, ProductDto> _findProduct;
        private readonly ICommandHandler<RegisterProduct, ProductDto> _registerProduct;

        #region Creation

        public ProductsController(
            IQueryHandler<FindProduct, ProductDto> findProduct,
            ICommandHandler<RegisterProduct, ProductDto> registerProduct
        )
        {
            _findProduct = findProduct;
            _registerProduct = registerProduct;
        }

        #endregion

        #region Public Interface

        [HttpGet("{recordName}", Name = "FindProduct")]
        public ActionResult<ProductDto> FindProduct(string recordName) => _findProduct.Handle(recordName);

        [HttpPost]
        public ActionResult<ProductDto> RegisterProduct([FromBody] RegisterProduct command)
        {
            var product = _registerProduct.Handle(command);

            return CreatedAtRoute(
                nameof(FindProduct),
                new { product.RecordName },
                product
            );
        }

        #endregion
    }
}
