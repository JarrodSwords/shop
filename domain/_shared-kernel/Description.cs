using Jgs.Ddd;

namespace Shop.Domain
{
    public class Description : TinyType<string>
    {
        #region Creation

        public Description(string value) : base(value)
        {
        }

        #endregion
    }
}
