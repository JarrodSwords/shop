using FluentAssertions;
using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;
using Xunit;

namespace Shop.Catalog.Spec
{
    public class GivenACandidateVendor_WithIncompleteData
    {
        public class WhenCreatingTheVendor
        {
            #region Core

            private readonly Result<Vendor> _result;

            public WhenCreatingTheVendor()
            {
                _result = Vendor.From(new IncompleteVendor());
            }

            #endregion

            #region Test Methods

            [Fact]
            public void ThenNameIsRequired()
            {
                _result.Message.Should().Contain("Name is required.");
            }

            [Fact]
            public void ThenSkuAbbreviationIsRequired()
            {
                _result.Message.Should().Contain("Sku token is required.");
            }

            #endregion

            private record IncompleteVendor : IVendorBuilder
            {
                #region IVendorBuilder Implementation

                public Id GetId() => default;
                public Name GetName() => default;
                public Token GetSkuToken() => default;

                #endregion
            }
        }
    }
}
