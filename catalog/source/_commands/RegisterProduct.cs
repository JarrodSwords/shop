using Jgs.Cqrs;
using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Catalog
{
    public record RegisterProduct(
        Id VendorId,
        ProductCategories Categories,
        Description Description,
        Name Name,
        Token SkuToken,
        Size Size = default
    ) : ICommand
    {
        public class ProductBuilder : IProductBuilder
        {
            private readonly Product.Builder _builder;
            private readonly IUnitOfWork _uow;
            private RegisterProduct _command;
            private Vendor _vendor;

            #region Creation

            public ProductBuilder(IUnitOfWork uow)
            {
                _builder = new();
                _uow = uow;
            }

            #endregion

            #region Public Interface

            public Product Build() => _builder.Build().Value;

            public ProductBuilder From(RegisterProduct args)
            {
                _command = args;

                _builder
                    .With(args.Categories)
                    .With(args.Description)
                    .With(args.Name)
                    .With(args.Size)
                    .With(args.VendorId);

                return this;
            }

            #endregion

            #region IProductBuilder Implementation

            public IProductBuilder FindVendor()
            {
                _vendor = _uow.Vendors.Find(_command.VendorId);
                return this;
            }

            public IProductBuilder GenerateSku()
            {
                var sku = Product.GenerateSku(
                    _vendor.SkuToken,
                    _command.Categories.GetToken(),
                    _command.SkuToken
                );

                _builder.With(sku);

                return this;
            }

            #endregion
        }
    }
}
