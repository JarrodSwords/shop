using Jgs.Ddd;
using Jgs.Functional;

namespace Shop.Shared
{
    public class Email : TinyType<string>
    {
        #region Creation

        private Email(string value) : base(value)
        {
        }

        public static Result<Email> From(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<Email>("Email is required");

            return Result.Success(new Email(value));
        }

        #endregion

        #region Static Interface

        public static implicit operator Email(string source) => new(source);

        #endregion
    }
}
