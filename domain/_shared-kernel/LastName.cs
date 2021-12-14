using Jgs.Ddd;

namespace Shop.Domain
{
    public class LastName : TinyType<string>
    {
        #region Creation

        public LastName(string value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator LastName(string source) => new(source);

        #endregion
    }
}
