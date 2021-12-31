using FluentAssertions;
using Jgs.Cqrs;
using Microsoft.Extensions.DependencyInjection;
using Shop.Catalog;
using Shop.Catalog.Services;
using Xunit;

namespace Shop.Api.Spec.Catalog
{
    [Collection("storage")]
    public class WhenCreatingAProduct : ServiceFixture
    {
        #region Core

        private readonly CompanyDto _company;
        private readonly IQueryHandler<FindProduct, ProductDto> _findProduct;
        private readonly ICommandHandler<RegisterProduct, RegisterProduct.ProductDto> _registerProduct;

        public WhenCreatingAProduct(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _registerProduct = ServiceProvider
                .GetRequiredService<ICommandHandler<RegisterProduct, RegisterProduct.ProductDto>>();

            _findProduct = ServiceProvider.GetRequiredService<IQueryHandler<FindProduct, ProductDto>>();

            var findCompanyByName = ServiceProvider.GetRequiredService<IQueryHandler<FindCompanyByName, CompanyDto>>();
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
