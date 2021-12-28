using Jgs.Ddd;

namespace Shop.Shared
{
    public class Token : TinyType<string>
    {
        #region Creation

        public Token(string value) : base(value)
        {
        }

        public static Token From(
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

        public static implicit operator Token(string source) => new(source);

        #endregion
    }
}
