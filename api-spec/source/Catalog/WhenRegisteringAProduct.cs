using FluentAssertions;
using Jgs.Cqrs;
using Jgs.Functional;
using Shop.Catalog;
using Shop.Catalog.Services;
using Shop.Shared;
using Xunit;

namespace Shop.Api.Spec.Catalog
{
    [Collection("storage")]
    public class WhenRegisteringAProduct : ApplicationFixture
    {
        #region Core

        private readonly IQueryHandler<FindProduct, ProductDto> _findProduct;
        private readonly ICommandHandler<RegisterProduct, Result<ProductRegistered>> _registerProduct;

        public WhenRegisteringAProduct(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _findProduct = Resolve<IQueryHandler<FindProduct, ProductDto>>();
            _registerProduct = Resolve<ICommandHandler<RegisterProduct, Result<ProductRegistered>>>();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ThenProductExistsInCatalog()
        {
            var command = new RegisterProduct(
                Vendor.ManyLoves.Id,
                ProductCategories.Box,
                "a foo",
                "foo",
                "f"
            );

            var productRegistered = _registerProduct.Handle(command).Value;
            var product = _findProduct.Handle(productRegistered.Sku);

            product.Should().NotBeNull();
        }

        #endregion
    }
}
