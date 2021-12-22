using Jgs.Ddd;

namespace Shop.Shared
{
    public class Abbreviation : TinyType<string>
    {
        #region Creation

        public Abbreviation(string value) : base(value)
        {
        }

        public static Abbreviation From(
            string source,
            int length = 3,
            char paddingChar = '0'
        )
        {
            if (source.Length < length)
                source = source.PadRight(length - source.Length, paddingChar);

            return new(source[..length]);
        }

        #endregion

        #region Static Interface

        public static implicit operator Abbreviation(string value) => new(value);

        #endregion
    }
}
