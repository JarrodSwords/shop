using System;
using Jgs.Cqrs;
using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Catalog.Services
{
    public record RegisterProduct(
        Guid CompanyId,
        ProductCategories Categories,
        string Description,
        string Name,
        string SkuToken,
        ushort Size = default
    ) : ICommand
    {
        public class Builder : IProductBuilder
        {
            private readonly IUnitOfWork _uow;
            private RegisterProduct _command;

            #region Creation

            public Builder(IUnitOfWork uow)
            {
                _uow = uow;
            }

            #endregion

            #region Public Interface

            public Builder From(RegisterProduct args)
            {
                _command = args;
                return this;
            }

            #endregion

            #region IProductBuilder Implementation

            public ProductCategories GetCategories() => _command.Categories;
            public Id GetCompanyId() => _command.CompanyId;
            public Description GetDescription() => _command.Description;
            public Name GetName() => _command.Name;
            public Size GetSize() => _command.Size;

            public Sku GetSku()
            {
                var company = _uow.Companies.Find(_command.CompanyId);

                return new Sku($"{company.SkuToken}-{_command.Categories.GetToken()}-{_command.SkuToken}");
            }

            #endregion
        }

        public class Handler : Handler<RegisterProduct, ProductDto>
        {
            private readonly Builder _builder;

            #region Creation

            public Handler(IUnitOfWork uow, Builder builder) : base(uow)
            {
                _builder = builder;
            }

            #endregion

            #region Public Interface

            public override ProductDto Handle(RegisterProduct args)
            {
                _builder.From(args);

                var product = Product.From(_builder).Value;

                Uow.Products.Create(product);
                Uow.Commit();

                return new(product.Sku);
            }

            #endregion
        }

        public record ProductDto(string Sku);
    }
}
