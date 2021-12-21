using Jgs.Cqrs;

namespace Shop.Catalog.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IQueryHandler<FindProduct, ProductDto> _findProductHandler;
        private readonly ICommandHandler<RegisterProduct, ProductDto> _registerProductHandler;

        #region Creation

        public CatalogService(
            IQueryHandler<FindProduct, ProductDto> findProductHandler,
            ICommandHandler<RegisterProduct, ProductDto> registerProductHandler
        )
        {
            _findProductHandler = findProductHandler;
            _registerProductHandler = registerProductHandler;
        }

        #endregion

        #region ICatalogService Implementation

        public ProductDto FindProduct(FindProduct command) => _findProductHandler.Handle(command);
        public ProductDto RegisterProduct(RegisterProduct command) => _registerProductHandler.Handle(command);

        #endregion
    }
}
