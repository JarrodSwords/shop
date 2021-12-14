using Jgs.Ddd;

namespace Shop.Domain
{
    public class Name : TinyType<string>
    {
        #region Creation

        public Name(string value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Name(string name) => new(name);

        #endregion
    }
}
