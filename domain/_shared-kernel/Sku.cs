using Jgs.Ddd;

namespace Shop.Domain
{
    public class Sku : TinyType<string>
    {
        #region Creation

        public Sku(string value) : base(value)
        {
        }

        #endregion
    }
}
