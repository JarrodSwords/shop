using Jgs.Cqrs;
using Shop.Shared;

namespace Shop.Catalog.Services
{
    public record RegisterProduct(
        string Category,
        string Description,
        string Name,
        string SkuToken,
        ushort Size = default
    ) : ICommand, IProductBuilder
    {
        #region IProductBuilder Implementation

        public ProductCategory GetCategory() => ProductCategory.Box;
        public Company GetCompany() => Company.ManyLoves;
        public Description GetDescription() => Description;
        public Name GetName() => Name;
        public Size GetSize() => Size;
        public Token GetSkuToken() => SkuToken;

        #endregion

        public class Handler : Handler<RegisterProduct, ProductDto>
        {
            #region Creation

            public Handler(IUnitOfWork uow) : base(uow)
            {
            }

            #endregion

            #region Public Interface

            public override ProductDto Handle(RegisterProduct args)
            {
                var product = Product.From(args).Value;

                Uow.Products.Create(product);
                Uow.Commit();

                return ProductDto.From(product);
            }

            #endregion
        }
    }
}
