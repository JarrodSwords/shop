using Jgs.Ddd;

namespace Shop.Shared
{
    public class Quantity : TinyType<ushort>
    {
        #region Creation

        public Quantity(ushort value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Quantity(ushort source) => new(source);

        #endregion
    }
}
