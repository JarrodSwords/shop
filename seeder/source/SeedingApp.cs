using Jgs.Cqrs;
using Jgs.Functional;
using Shop.Catalog;
using Shop.Catalog.Services;
using Shop.Sales.Products;

namespace Shop.Seeder
{
    public class SeedingApp
    {
        private readonly ICommandHandler<RegisterProduct, Result<ProductRegistered>> _registerProduct;
        private readonly ICommandHandler<RegisterVendor, VendorDto> _registerVendor;
        private readonly ICommandHandler<SetPrice> _setPrice;

        #region Creation

        public SeedingApp(
            ICommandHandler<RegisterProduct, Result<ProductRegistered>> registerProduct,
            ICommandHandler<RegisterVendor, VendorDto> registerVendor,
            ICommandHandler<SetPrice> setPrice
        )
        {
            _registerProduct = registerProduct;
            _registerVendor = registerVendor;
            _setPrice = setPrice;
        }

        #endregion

        #region Public Interface

        public void Run()
        {
            SeedVendors();
            SeedProducts();
        }

        #endregion

        #region Private Interface

        private void SeedProducts()
        {
            foreach (var p in ObjectProvider.Products)
            {
                var productRegistered = _registerProduct.Handle(
                    new(
                        p.VendorId,
                        p.Categories,
                        p.Description,
                        p.Name,
                        p.SkuToken,
                        p.Size
                    )
                );

                if (productRegistered.IsFailure)
                    continue;

                _setPrice.Handle(new(p.Price, productRegistered.Value.Sku));
            }
        }

        private void SeedVendors()
        {
            _registerVendor.Handle(new(Vendor.ManyLoves.Name, Vendor.ManyLoves.SkuToken));
        }

        #endregion
    }
}
