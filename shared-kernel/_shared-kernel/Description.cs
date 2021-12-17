using Jgs.Ddd;

namespace Shop.Shared
{
    public class Description : TinyType<string>
    {
        #region Creation

        public Description(string value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Description(string value) => new(value);

        #endregion
    }
}
