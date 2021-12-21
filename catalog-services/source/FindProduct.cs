using Jgs.Cqrs;

namespace Shop.Catalog.Services
{
    public record FindProduct(string RecordName) : IQuery
    {
        #region Static Interface

        public static implicit operator FindProduct(string source) => new(source);

        #endregion
    }
}
