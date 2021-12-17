using Jgs.Ddd;

namespace Shop.Shared
{
    public class FirstName : TinyType<string>
    {
        #region Creation

        public FirstName(string value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator FirstName(string source) => new(source);

        #endregion
    }
}
