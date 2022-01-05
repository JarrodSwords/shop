using System.Collections.Generic;
using Shop.Catalog;

namespace Shop.Seeder
{
    public class SeedingApp
    {
        private readonly ProductBuilder _productBuilder = new();
        private readonly IUnitOfWork _uow;

        #region Creation

        public SeedingApp(IUnitOfWork uow)
        {
            _uow = uow;
        }

        #endregion

        #region Public Interface

        public void Run()
        {
            _uow.Vendors.Create(Vendor.ManyLoves);

            var productDirector = new Product.Director().With(_productBuilder);

            List<Product> products = new();

            foreach (var p in CandidateProduct.All)
            {
                _productBuilder.With(p);
                productDirector.ConfigureSeedProduct();
                products.Add(_productBuilder.Build());
            }

            _uow.Products.Create(products.ToArray());

            _uow.Commit();
        }

        #endregion
    }
}
