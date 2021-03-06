using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Shop.Shared.Spec
{
    public class WhenCreatingAnEmail
    {
        #region Public Interface

        public static IEnumerable<object[]> GetValidEmails()
        {
            yield return new object[] { "jon.doe@gmail.com" };
            yield return new object[] { "jane.doe@gmail.com" };
        }

        #endregion

        #region Test Methods

        [Theory]
        [MemberData(nameof(GetValidEmails))]
        public void ThenReturnAValidEmail(string value)
        {
            var email = Email.From(value).Value;

            email.Should().NotBeNull();
        }

        [Theory]
        [MemberData(nameof(GetValidEmails))]
        public void ThenReturnSuccess(string value)
        {
            var result = Email.From(value);

            result.IsSuccess.Should().BeTrue();
        }

        [Theory]
        [InlineData("jon.doe@gmail.com ")]
        [InlineData(" jon.doe@gmail.com")]
        [InlineData(" jon.doe@gmail.com ")]
        public void WithExtraWhitespace_ThenReturnTrimmedEmail(string value)
        {
            var email = Email.From(value).Value;

            email.Value.Should().Be(value.Trim());
        }

        [Theory]
        [InlineData("jon.doe@")]
        [InlineData("@gmail.com")]
        [InlineData("jon.doe2gmail.com")]
        public void WithInvalidEmail_ThenReturnInvalidError(string value)
        {
            var result = Email.From(value);

            result.IsFailure.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void WithoutAValue_ThenReturnRequiredError(string value)
        {
            var error = Email.From(value).Error;

            error.Should().Be(Error.Required());
        }

        #endregion
    }
}
