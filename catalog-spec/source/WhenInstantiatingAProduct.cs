using FluentAssertions;
using Shop.Shared;
using Xunit;

namespace Shop.Catalog.Spec
{
    public class WhenInstantiatingAProduct
    {
        #region Core

        private readonly ProductBuilder _builder;

        public WhenInstantiatingAProduct()
        {
            _builder = new ProductBuilder()
                .With((Name) "Foo")
                .With((Token) "f")
                .With(Company.ManyLoves)
                .With(ProductCategories.Box)
                .With((Description) "a foo");
        }

        #endregion

        #region Test Methods

        [Theory]
        [InlineData("n")]
        [InlineData("b", true)]
        [InlineData("d", false, true)]
        [InlineData("s", false, false, true)]
        [InlineData("bd", true, true, false)]
        [InlineData("ds", false, true, true)]
        public void ThenSkuIsGenerated(
            string expectedCategoryToken,
            bool isBox = false,
            bool isDessert = false,
            bool isSide = false
        )
        {
            var categories = ProductCategories.None;

            if (isBox)
                categories |= ProductCategories.Box;

            if (isDessert)
                categories |= ProductCategories.Dessert;

            if (isSide)
                categories |= ProductCategories.Side;

            var product = _builder.With(categories).Build();

            Sku expected = $"mlc-{expectedCategoryToken}-f".ToLower();

            product.Sku.Should().Be(expected);
        }

        #endregion
    }
}
