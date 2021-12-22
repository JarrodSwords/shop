using Jgs.Cqrs;
using Shop.Shared;

namespace Shop.Catalog.Services
{
    public record RegisterProduct(
        string Category,
        string Description,
        string Name,
        decimal Price,
        string Size
    ) : ICommand, IProductBuilder
    {
        #region IProductBuilder Implementation

        public ProductCategory GetCategory() => default;
        public Description GetDescription() => Description;
        public Name GetName() => Name;
        public Money GetPrice() => Price;
        public Size GetSize() => Size;

        #endregion

        public class Handler : ICommandHandler<RegisterProduct, ProductDto>
        {
            private readonly IUnitOfWork _uow;

            #region Creation

            public Handler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            #endregion

            #region ICommandHandler<RegisterProduct,ProductDto> Implementation

            public ProductDto Handle(RegisterProduct command)
            {
                var product = Product.From(command).Value;

                _uow.Products.Create(product);
                _uow.Commit();

                return ProductDto.From(product);
            }

            #endregion
        }
    }
}
