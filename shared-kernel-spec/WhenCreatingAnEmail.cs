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
        public void ThenAValidEmailIsReturned(string input)
        {
            var email = Email.From(input);

            email.Should().NotBeNull();
        }

        [Theory]
        [MemberData(nameof(GetValidEmails))]
        public void ThenResultIsSuccess(string input)
        {
            var email = Email.From(input);

            email.Should().NotBeNull();
        }

        #endregion
    }
}
