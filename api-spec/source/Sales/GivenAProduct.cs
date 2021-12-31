using FluentAssertions;
using Jgs.Cqrs;
using Shop.Catalog;
using Shop.Catalog.Services;
using Shop.Sales.Services;
using Shop.Shared;
using Xunit;
using FindProduct = Shop.Sales.Services.FindProduct;
using ProductDto = Shop.Sales.Services.ProductDto;

namespace Shop.Api.Spec.Sales
{
    [Collection("storage")]
    public class GivenAProduct : ApplicationFixture
    {
        #region Core

        private readonly IQueryHandler<FindProduct, ProductDto> _findProduct;
        private readonly ICommandHandler<SetPrice> _setPrice;
        private readonly string _sku;

        public GivenAProduct(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _findProduct = Resolve<IQueryHandler<FindProduct, ProductDto>>();
            _setPrice = Resolve<ICommandHandler<SetPrice>>();

            var registerProduct = Resolve<ICommandHandler<RegisterProduct, RegisterProduct.ProductDto>>();
            var findCompanyByName = Resolve<IQueryHandler<FindCompanyByName, CompanyDto>>();

            var company = findCompanyByName.Handle("Many Loves Charcuterie");

            _sku = registerProduct.Handle(
                new(
                    company.Id,
                    ProductCategories.Box,
                    "a bar", "Bar", "b"
                )
            ).Sku;
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
