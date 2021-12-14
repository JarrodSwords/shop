using FluentAssertions;
using Shop.Domain.Catalog;
using Xunit;

namespace Shop.Domain.Spec.Catalog
{
    public class GivenAllRequiredFields
    {
        #region Core

        private readonly Name _name = "Lunch Box";
        private readonly Product _product;

        public GivenAllRequiredFields()
        {
            _product = new Product(_name);
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCreating_ThenNameIsSet()
        {
            _product.Name.Should().Be(_name);
        }

        #endregion
    }
}
