using Jgs.Cqrs;
using Microsoft.AspNetCore.Mvc;
using Shop.Sales.Services;
using Shop.Sales.Services.Products;

namespace Shop.Api.Sales
{
    [Route("api/sales/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IQueryHandler<FindProduct, ProductDto> _findProduct;

        #region Creation

        public ProductsController(IQueryHandler<FindProduct, ProductDto> findProduct)
        {
            _findProduct = findProduct;
        }

        #endregion

        #region Public Interface

        [HttpGet("{recordName}")]
        public ActionResult<ProductDto> FindProduct(string recordName) => _findProduct.Handle(recordName);

        #endregion
    }
}
