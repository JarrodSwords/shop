using System.Text.RegularExpressions;
using Jgs.Ddd;
using Jgs.Functional.Explicit;

namespace Shop.Shared
{
    public class Email : TinyType<string>
    {
        #region Creation

        private Email(string value) : base(value)
        {
        }

        public static Result<Email, Error> From(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Error.Required(nameof(email));

            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
                return Error.Invalid(nameof(email));

            return new Email(email);
        }

        #endregion

        #region Static Interface

        public static implicit operator Email(string source) => From(source).Value;

        #endregion
    }
}
