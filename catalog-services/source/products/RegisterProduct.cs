﻿using System;
using Jgs.Cqrs;
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
            private readonly Product.Builder _builder;
            private readonly IUnitOfWork _uow;
            private RegisterProduct _command;
            private Company _company;

            #region Creation

            public Builder(IUnitOfWork uow)
            {
                _builder = new();
                _uow = uow;
            }

            #endregion

            #region Public Interface

            public Product Build() => _builder.Build().Value;

            public Builder From(RegisterProduct args)
            {
                _command = args;

                _builder
                    .With((Description) args.Description)
                    .With((Name) args.Name)
                    .With(args.Categories)
                    .With(args.Size)
                    .With(args.CompanyId);

                return this;
            }

            #endregion

            #region IProductBuilder Implementation

            public IProductBuilder FindCompany()
            {
                _company = _uow.Companies.Find(_command.CompanyId);
                return this;
            }

            public IProductBuilder GenerateSku()
            {
                var sku = Product.GenerateSku(
                    _company.SkuToken,
                    _command.Categories.GetToken(),
                    _company.SkuToken
                );

                _builder.With(sku);

                return this;
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
                new Product.Director().With(_builder).ConfigureNewProduct();
                var product = _builder.Build();

                Uow.Products.Create(product);
                Uow.Commit();

                return new(product.Sku);
            }

            #endregion
        }

        public record ProductDto(string Sku);
    }
}
