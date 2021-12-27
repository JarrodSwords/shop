using Jgs.Ddd;

namespace Shop.Shared
{
    public class Size : TinyType<string>
    {
        #region Creation

        public Size(string value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Size(string source) => new(source);

        #endregion
    }
}
