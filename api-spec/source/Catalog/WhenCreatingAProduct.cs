using FluentAssertions;
using Jgs.Cqrs;
using Shop.Catalog;
using Shop.Catalog.Services;
using Xunit;

namespace Shop.Api.Spec.Catalog
{
    [Collection("storage")]
    public class WhenCreatingAProduct : ApplicationFixture
    {
        #region Core

        private readonly IQueryHandler<FindProduct, ProductDto> _findProduct;
        private readonly ICommandHandler<RegisterProduct, ProductRegistered> _registerProduct;

        public WhenCreatingAProduct(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _findProduct = Resolve<IQueryHandler<FindProduct, ProductDto>>();
            _registerProduct = Resolve<ICommandHandler<RegisterProduct, ProductRegistered>>();
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

            var productRegistered = _registerProduct.Handle(command);
            var product = _findProduct.Handle(productRegistered.Sku);

            product.Should().NotBeNull();
        }

        #endregion
    }
}
