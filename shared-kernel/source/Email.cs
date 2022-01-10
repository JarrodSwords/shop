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

        public static Result<Email, Error> From(string value) =>
            string.IsNullOrWhiteSpace(value)
                ? Error.Required(nameof(value))
                : new Email(value);

        #endregion

        #region Static Interface

        public static implicit operator Email(string source) => new(source);

        #endregion
    }
}
