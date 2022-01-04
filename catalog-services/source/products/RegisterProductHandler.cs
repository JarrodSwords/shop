namespace Shop.Catalog.Services
{
    public class RegisterProductHandler : Handler<RegisterProduct, ProductRegistered>
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

        public override ProductRegistered Handle(RegisterProduct args)
        {
            _builder.From(args);

            new Product.Director()
                .With(_builder)
                .ConfigureNewProduct();

            var product = _builder.Build();

            Uow.Products.Create(product);
            Uow.Commit();

            return new(product.Sku);
        }

        #endregion
    }
}
