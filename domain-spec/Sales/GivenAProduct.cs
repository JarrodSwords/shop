using FluentAssertions;
using Shop.Domain.Sales;
using Xunit;

namespace Shop.Domain.Spec.Sales
{
    public class GivenAProduct
    {
        #region Core

        private readonly Product _product;

        public GivenAProduct()
        {
            _product = new("MLC-LB-1");
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenSettingPrice_ThenPriceIsSet()
        {
            _product.Set(25m);

            _product.Price.Should().Be(new Money(25m));
        }

        #endregion
    }
}
