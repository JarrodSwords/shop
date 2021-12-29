﻿using FluentAssertions;
using Jgs.Cqrs;
using Microsoft.Extensions.DependencyInjection;
using Shop.Catalog.Services;
using Shop.Sales.Services;
using Shop.Shared;
using Xunit;
using FindProduct = Shop.Sales.Services.FindProduct;
using ProductDto = Shop.Sales.Services.ProductDto;

namespace Shop.Api.Spec.Sales
{
    [Collection("storage")]
    public class GivenAProduct : ServiceFixture
    {
        #region Core

        private readonly IQueryHandler<FindProduct, ProductDto> _findProduct;
        private readonly ICommandHandler<RegisterProduct, Shop.Catalog.Services.ProductDto> _registerProduct;
        private readonly ICommandHandler<SetPrice> _setPrice;
        private readonly string _sku;

        public GivenAProduct(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _findProduct = ServiceProvider.GetRequiredService<IQueryHandler<FindProduct, ProductDto>>();
            _registerProduct = ServiceProvider
                .GetRequiredService<ICommandHandler<RegisterProduct, Shop.Catalog.Services.ProductDto>>();
            _setPrice = ServiceProvider.GetRequiredService<ICommandHandler<SetPrice>>();

            _sku = _registerProduct.Handle(new("box", "a bar", "Bar", "b")).Sku;
        }

        #endregion

        #region Test Methods

        [Theory]
        [InlineData(9.99)]
        public void WhenSettingPrice_ThenProductIsUpdated(decimal price)
        {
            _setPrice.Handle(new(price, _sku));
            var product = _findProduct.Handle(_sku);

            product.Price.Should().Be((Money) price);
        }

        #endregion
    }
}
