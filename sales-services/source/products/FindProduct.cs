using Jgs.Cqrs;

namespace Shop.Sales.Services
{
    public record FindProduct(string Sku) : IQuery
    {
        #region Static Interface

        public static implicit operator FindProduct(string source) => new(source);

        #endregion
    }

    public record SetPrice(
        decimal Price,
        string Sku
    ) : ICommand
    {
        public class Handler : Handler<SetPrice>
        {
            #region Creation

            public Handler(IUnitOfWork uow) : base(uow)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(SetPrice args)
            {
                var (price, sku) = args;

                var product = Uow.Products.Find(sku);
                product.Set(price);

                Uow.Products.Update(product);
                Uow.Commit();
            }

            #endregion
        }
    }
}
