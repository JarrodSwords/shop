using System;
using Jgs.Cqrs;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog;
using Shop.Catalog.Services;

namespace Shop.Api.Catalog
{
    [Route("api/catalog/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IQueryHandler<FindProduct, ProductDto> _findProduct;
        private readonly ICommandHandler<RegisterProduct, ProductRegistered> _registerProduct;

        #region Creation

        public ProductsController(
            IQueryHandler<FindProduct, ProductDto> findProduct,
            ICommandHandler<RegisterProduct, ProductRegistered> registerProduct
        )
        {
            _findProduct = findProduct;
            _registerProduct = registerProduct;
        }

        #endregion

        #region Public Interface

        [HttpGet("{sku}", Name = "FindProduct")]
        public ActionResult<ProductDto> FindProduct(string sku) => _findProduct.Handle(sku);

        [HttpPost]
        public ActionResult<ProductDto> RegisterProduct([FromBody] RegisterProductDto dto)
        {
            var product = _registerProduct.Handle(dto);

            return CreatedAtRoute(
                nameof(FindProduct),
                product,
                product
            );
        }

        #endregion

        public record RegisterProductDto(
            Guid VendorId,
            string Description,
            string Name,
            string SkuToken,
            bool IsBox = default,
            bool IsDessert = default,
            bool IsSide = default,
            ushort Size = default
        )
        {
            #region Static Interface

            public static implicit operator RegisterProduct(RegisterProductDto source)
            {
                var categories = ProductCategories.None;

                if (source.IsBox)
                    categories |= ProductCategories.Box;

                if (source.IsDessert)
                    categories |= ProductCategories.Dessert;

                if (source.IsSide)
                    categories |= ProductCategories.Side;

                return new(
                    source.VendorId,
                    categories,
                    source.Description,
                    source.Name,
                    source.SkuToken,
                    source.Size
                );
            }

            #endregion
        }
    }
}
