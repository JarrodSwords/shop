using Jgs.Functional;

namespace Shop.Catalog.Services
{
    public class RegisterProductHandler : Handler<RegisterProduct, Result<ProductRegistered>>
    {
        private readonly RegisterProduct.ProductBuilder _builder;

        #region Creation

        public RegisterProductHandler(
            IUnitOfWork uow,
            RegisterProduct.ProductBuilder builder
        ) : base(uow)
        {
            _builder = builder;
        }

        #endregion

        #region Public Interface

        public override Result<ProductRegistered> Handle(RegisterProduct args)
        {
            _builder.From(args);

            new Product.Director()
                .With(_builder)
                .ConfigureRegisterProduct();

            var product = _builder.Build();

            if (Uow.Products.Exists(product.Sku))
                return Result.Failure<ProductRegistered>($"Cannot register duplicate sku \"{product.Sku}\"");

            Uow.Products.Create(product);
            Uow.Commit();

            return Result.Success(new ProductRegistered(product.Sku));
        }

        #endregion
    }
}
