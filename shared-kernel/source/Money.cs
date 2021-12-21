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
        public static Money operator +(Money left, Money right) => new(left.Value + right.Value);
        public static Money operator *(Money money, Quantity quantity) => new(money.Value * quantity.Value);
        public static Money operator *(Quantity quantity, Money money) => money * quantity;

        #endregion
    }

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
