using Jgs.Cqrs;

namespace Shop.Sales.Services
{
    public record FindProduct(string RecordName) : IQuery
    {
        #region Static Interface

        public static implicit operator FindProduct(string source) => new(source);

        #endregion
    }
}
