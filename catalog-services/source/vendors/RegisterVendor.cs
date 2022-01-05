using System;
using Jgs.Cqrs;
using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Catalog.Services
{
    public record RegisterVendor(
        string Name,
        string SkuToken
    ) : ICommand, IVendorBuilder
    {
        #region IVendorBuilder Implementation

        public Id GetId() => default;
        public Name GetName() => Name;
        public Token GetSkuToken() => SkuToken;

        #endregion

        public class Handler : Handler<RegisterVendor, VendorDto>
        {
            #region Creation

            public Handler(IUnitOfWork uow) : base(uow)
            {
            }

            #endregion

            #region Public Interface

            public override VendorDto Handle(RegisterVendor args)
            {
                var vendor = Vendor.From(args).Value;

                Uow.Vendors.Create(vendor);
                Uow.Commit();

                return new(vendor.Id);
            }

            #endregion
        }

        public record VendorDto(Guid Id);
    }
}
