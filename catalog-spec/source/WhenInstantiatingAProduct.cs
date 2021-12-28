using FluentAssertions;
using Shop.Shared;
using Xunit;

namespace Shop.Catalog.Spec
{
    public class WhenInstantiatingAProduct
    {
        #region Test Methods

        [Fact]
        public void ThenSkuIsGenerated()
        {
            var company = Company.ManyLoves;
            var category = ProductCategory.Box;
            Token skuToken = "f";
            var product = new ProductBuilder()
                .With((Name) "Foo")
                .With(skuToken)
                .With(company)
                .With(ProductCategory.Box)
                .With((Description) "a foo box")
                .Build();

            Sku expected = $"{company.SkuToken}-{category.SkuToken}-{skuToken}".ToLower();

            product.Sku.Should().Be(expected);
        }

        #endregion
    }
}
