using Jgs.Cqrs;
using Jgs.Functional;
using Shop.Catalog;
using Shop.Catalog.Services;

namespace Shop.Seeder
{
    public class SeedingApp
    {
        private readonly ICommandHandler<RegisterProduct, Result<ProductRegistered>> _registerProduct;
        private readonly IUnitOfWork _uow;

        #region Creation

        public SeedingApp(
            ICommandHandler<RegisterProduct, Result<ProductRegistered>> registerProduct,
            IUnitOfWork uow
        )
        {
            _registerProduct = registerProduct;
            _uow = uow;
        }

        #endregion

        #region Public Interface

        public void Run()
        {
            _uow.Vendors.Create(Vendor.ManyLoves);
            _uow.Commit();

            foreach (var p in ObjectProvider.Products)
                _registerProduct.Handle(p);

            _uow.Commit();
        }

        #endregion
    }
}
