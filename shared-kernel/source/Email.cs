using Jgs.Ddd;
using Jgs.Functional;
using static Jgs.Functional.Result;

namespace Shop.Shared
{
    public class Email : TinyType<string>
    {
        #region Creation

        private Email(string value) : base(value)
        {
        }

        public static Result<Email> From(string value) =>
            string.IsNullOrWhiteSpace(value)
                ? Failure<Email>("Email is required")
                : Success(new Email(value));

        #endregion

        #region Static Interface

        public static implicit operator Email(string source) => new(source);

        #endregion
    }
}
