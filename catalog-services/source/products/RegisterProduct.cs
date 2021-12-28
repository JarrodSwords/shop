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

        public ProductCategory GetCategory() => ProductCategory.Box;
        public Description GetDescription() => Description;
        public Name GetName() => Name;
        public Money GetPrice() => Price;
        public Size GetSize() => Size;

        #endregion

        public class Handler : Handler<RegisterProduct, ProductDto>
        {
            #region Creation

            public Handler(IUnitOfWork uow) : base(uow)
            {
            }

            #endregion

            #region Public Interface

            public override ProductDto Handle(RegisterProduct command)
            {
                var product = Product.From(command).Value;

                Uow.Products.Create(product);
                Uow.Commit();

                return ProductDto.From(product);
            }

            #endregion
        }
    }
}
