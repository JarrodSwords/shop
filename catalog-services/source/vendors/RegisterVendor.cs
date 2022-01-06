using Jgs.Functional;

namespace Shop.Catalog.Services
{
    public class RegisterVendorHandler : Handler<RegisterVendor, Result<VendorRegistered>>
    {
        #region Creation

        public RegisterVendorHandler(IUnitOfWork uow) : base(uow)
        {
        }

        #endregion

        #region Public Interface

        public override Result<VendorRegistered> Handle(RegisterVendor args)
        {
            var (name, skuToken) = args;

            var vendor = new Vendor.Builder()
                .With(name)
                .With(skuToken)
                .Build().Value;

            Uow.Vendors.Create(vendor);
            Uow.Commit();

            return Result.Success(new VendorRegistered(vendor.Id));
        }

        #endregion
    }
}
