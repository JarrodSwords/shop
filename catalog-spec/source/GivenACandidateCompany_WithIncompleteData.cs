using FluentAssertions;
using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;
using Xunit;

namespace Shop.Catalog.Spec
{
    public class GivenACandidateCompany_WithIncompleteData
    {
        public class WhenCreatingTheCompany
        {
            #region Core

            private readonly Result<Company> _result;

            public WhenCreatingTheCompany()
            {
                _result = Company.From(new IncompleteCompany());
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

            private record IncompleteCompany : ICompanyBuilder
            {
                #region ICompanyBuilder Implementation

                public Id GetId() => default;
                public Name GetName() => default;
                public Token GetSkuToken() => default;

                #endregion
            }
        }
    }
}
