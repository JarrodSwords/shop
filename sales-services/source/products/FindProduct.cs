using Jgs.Cqrs;

namespace Shop.Sales.Services.Products
{
    public record FindProduct(string Sku) : IQuery
    {
        #region Static Interface

        public static implicit operator FindProduct(string source) => new(source);

        #endregion
    }
}
