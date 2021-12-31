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

        private readonly CompanyDto _company;
        private readonly IQueryHandler<FindProduct, ProductDto> _findProduct;
        private readonly ICommandHandler<RegisterProduct, RegisterProduct.ProductDto> _registerProduct;

        public WhenCreatingAProduct(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _registerProduct = Resolve<ICommandHandler<RegisterProduct, RegisterProduct.ProductDto>>();
            _findProduct = Resolve<IQueryHandler<FindProduct, ProductDto>>();

            var findCompanyByName = Resolve<IQueryHandler<FindCompanyByName, CompanyDto>>();
            _company = findCompanyByName.Handle("Many Loves Charcuterie");
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ThenProductExistsInCatalog()
        {
            var savedProduct = _registerProduct.Handle(new(_company.Id, ProductCategories.Box, "a foo", "foo", "f"));
            var product = _findProduct.Handle(savedProduct.Sku);

            product.Should().NotBeNull();
        }

        #endregion
    }
}
