using FluentAssertions;
using Jgs.Cqrs;
using Jgs.Functional;
using Shop.Catalog;
using Shop.Catalog.Services;
using Xunit;

namespace Shop.Api.Spec.Catalog
{
    [Collection("storage")]
    public class WhenRegisteringAnExistingProduct : ApplicationFixture
    {
        #region Core

        private readonly IQueryHandler<FindProduct, ProductDto> _findProduct;
        private readonly ICommandHandler<RegisterProduct, Result<ProductRegistered>> _registerProduct;

        public WhenRegisteringAnExistingProduct(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _findProduct = Resolve<IQueryHandler<FindProduct, ProductDto>>();
            _registerProduct = Resolve<ICommandHandler<RegisterProduct, Result<ProductRegistered>>>();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ThenProductRegistrationFails()
        {
            var command = new RegisterProduct(
                Vendor.ManyLoves.Id,
                ProductCategories.Box,
                Product.LunchBox.Description,
                Product.LunchBox.Name,
                "lun"
            );

            var result = _registerProduct.Handle(command);

            result.IsFailure.Should().BeTrue();
        }

        #endregion
    }
}
