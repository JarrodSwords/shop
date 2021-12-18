using FluentAssertions;
using Shop.Shared.Catalog;
using Xunit;

namespace Shop.Shared.Spec.Catalog.Products
{
    public class GivenAProduct
    {
        #region Core

        private readonly Product _product = ObjectProvider.CreateLunchBox();

        #endregion

        #region Test Methods

        [Fact]
        public void WhenUpdatingDescription_ThenDescriptionIsUpdated()
        {
            Description newDescription = "new description";

            _product.Update(newDescription);

            _product.Description.Should().Be(newDescription);
        }

        #endregion
    }
}
