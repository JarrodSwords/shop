using FluentAssertions;
using Shop.Domain.Catalog;
using Xunit;

namespace Shop.Domain.Spec.Catalog.Products
{
    public class GivenAllRequiredFields
    {
        #region Core

        private readonly Name _name = "Lunch Box";
        private readonly Product _product;
        private readonly Serves _serves = new(1);

        public GivenAllRequiredFields()
        {
            _product = new Product(_name, _serves);
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCreating_ThenNameIsSet()
        {
            _product.Name.Should().Be(_name);
        }

        [Fact]
        public void WhenCreating_ThenServesIsSet()
        {
            _product.Serves.Should().Be(_serves);
        }

        #endregion
    }
}
