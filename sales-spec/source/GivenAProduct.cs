using FluentAssertions;
using Shop.Shared;
using Xunit;

namespace Shop.Sales.Spec
{
    public class GivenAProduct
    {
        #region Test Methods

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(9.99)]
        public void WhenSettingThePrice_ThenPriceIsCorrect(decimal price)
        {
            var product = new Product();

            product.Set(price);

            product.Price.Should().Be((Money) price);
        }

        #endregion
    }
}
