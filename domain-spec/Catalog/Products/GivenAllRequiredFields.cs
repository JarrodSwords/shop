using FluentAssertions;
using Shop.Domain.Catalog;
using Xunit;

namespace Shop.Domain.Spec.Catalog.Products
{
    public class GivenAllRequiredFields
    {
        #region Core

        private readonly Description _description =
            new("Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements.");

        private readonly Name _name = "Lunch Box";
        private readonly Product _product;
        private readonly Serves _serves = new(1);
        private readonly Sku _sku = new("MLC-LB-1");

        public GivenAllRequiredFields()
        {
            _product = new Product(_description, _name, _serves, _sku);
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCreating_ThenDescriptionIsSet()
        {
            _product.Description.Should().Be(_description);
        }

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

        [Fact]
        public void WhenCreating_ThenSkuIsSet()
        {
            _product.Sku.Should().Be(_sku);
        }

        #endregion
    }
}
