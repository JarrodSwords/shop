using FluentAssertions;
using Jgs.Cqrs;
using Shop.Sales.Services;
using Shop.Shared;
using Xunit;

namespace Shop.Api.Spec.Sales
{
    [Collection("storage")]
    public class GivenAProduct : ApplicationFixture
    {
        #region Core

        private const string Sku = "mlc-b-lun";
        private readonly IQueryHandler<FindProduct, ProductDto> _findProduct;
        private readonly ICommandHandler<SetPrice> _setPrice;

        public GivenAProduct(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _findProduct = Resolve<IQueryHandler<FindProduct, ProductDto>>();
            _setPrice = Resolve<ICommandHandler<SetPrice>>();
        }

        #endregion

        #region Test Methods

        [Theory]
        [InlineData(9.99)]
        public void WhenSettingPrice_ThenProductIsUpdated(decimal price)
        {
            _setPrice.Handle(new(price, Sku));
            var product = _findProduct.Handle(Sku);

            product.Price.Should().Be((Money) price);
        }

        #endregion
    }
}
