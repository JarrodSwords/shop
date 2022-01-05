using FluentAssertions;
using Jgs.Cqrs;
using Jgs.Functional;
using Shop.Catalog;
using Shop.Catalog.Services;
using Xunit;

namespace Shop.Api.Spec.Catalog
{
    [Collection("storage")]
    public class WhenRegisteringADuplicateProduct : ApplicationFixture
    {
        #region Core

        private readonly Result _result;

        public WhenRegisteringADuplicateProduct(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            var registerProduct = Resolve<ICommandHandler<RegisterProduct, Result<ProductRegistered>>>();

            var command = new RegisterProduct(
                Vendor.ManyLoves.Id,
                ProductCategories.Box,
                Product.LunchBox.Description,
                Product.LunchBox.Name,
                "lun"
            );

            _result = registerProduct.Handle(command);
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ThenDuplicateSkuIsRejected()
        {
            _result.Message.Should().Contain("Cannot register duplicate sku \"mlc-b-lun\"");
        }

        [Fact]
        public void ThenProductRegistrationFails()
        {
            _result.IsFailure.Should().BeTrue();
        }

        #endregion
    }
}
