using Jgs.Cqrs;
using Shop.Shared;

namespace Shop.Catalog.Services
{
    public record RegisterProduct(
        string Description,
        string Name,
        decimal Price
    ) : ICommand, IProductBuilder
    {
        #region IProductBuilder Implementation

        public Description GetDescription() => Description;
        public Name GetName() => Name;
        public Money GetPrice() => Price;

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
