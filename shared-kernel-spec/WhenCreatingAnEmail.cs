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
            var email = new Email(input);

            email.Should().NotBeNull();
        }

        #endregion
    }
}
