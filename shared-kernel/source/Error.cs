using System.Collections.Generic;
using Jgs.Ddd;

namespace Shop.Shared
{
    public class Error : ValueObject
    {
        #region Creation

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        #endregion

        #region Public Interface

        public string Code { get; }
        public string Message { get; }

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }

        #endregion

        #region Static Interface

        public static Error Invalid(string identifier = default, string reason = default)
        {
            const string invalid = "invalid";

            return identifier is null
                ? new(invalid, $"Value is {invalid}.")
                : new(invalid, $"{identifier} is {invalid}.");
        }

        public static Error Required(string identifier = default)
        {
            const string required = "required";

            return identifier is null
                ? new(required, $"Value is {required}.")
                : new(required, $"{identifier} is {required}.");
        }

        #endregion
    }
}
