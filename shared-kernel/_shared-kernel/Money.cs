using Jgs.Ddd;

namespace Shop.Shared
{
    public class Money : TinyType<decimal>
    {
        public static Money Zero = new(0);

        #region Creation

        public Money(decimal value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Money(decimal source) => new(source);

        #endregion
    }
}
