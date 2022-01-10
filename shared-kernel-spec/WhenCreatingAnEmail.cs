using FluentAssertions;
using Xunit;

namespace Shop.Shared.Spec
{
    public class WhenCreatingAnEmail
    {
        #region Test Methods

        [Theory]
        [InlineData("jon.doe@gmail.com")]
        [InlineData("jane.doe@gmail.com")]
        public void ThenAValidEmailIsReturned(string input)
        {
            var email = Email.From(input);

            email.Should().NotBeNull();
        }

        [Theory]
        [InlineData("jon.doe@gmail.com")]
        [InlineData("jane.doe@gmail.com")]
        public void ThenResultIsSuccess(string input)
        {
            var email = Email.From(input);

            email.Should().NotBeNull();
        }

        #endregion
    }
}
