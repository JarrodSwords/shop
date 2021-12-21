using Jgs.Ddd;

namespace Shop.Shared
{
    public class RecordName : TinyType<string>
    {
        #region Creation

        public RecordName(string value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator RecordName(string source) => new(source);

        #endregion
    }
}
