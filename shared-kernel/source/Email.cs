using Jgs.Ddd;

namespace Shop.Shared
{
    public class Email : TinyType<string>
    {
        #region Creation

        public Email(string value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Email(string source) => new(source);

        #endregion
    }
}
