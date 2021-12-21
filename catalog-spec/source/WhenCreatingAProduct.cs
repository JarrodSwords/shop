using FluentAssertions;
using Shop.Shared;
using Xunit;

namespace Shop.Catalog.Spec
{
    public class WhenCreatingAProduct
    {
        #region Test Methods

        [Theory]
        [InlineData("Baguettes", "baguettes")]
        [InlineData("Lunch Box", "lunch-box")]
        public void ThenSkuIsGenerated(string name, string expected)
        {
            var expectedRecordName = new RecordName(expected);
            var product = new ProductBuilder()
                .With(new Name(name))
                .With(new Description($"A {name}"))
                .With(1)
                .Build();

            product.RecordName.Should().Be(expectedRecordName);
        }

        #endregion
    }
}
