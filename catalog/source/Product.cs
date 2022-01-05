using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Catalog
{
    public partial class Product : Aggregate
    {
        public static readonly Product LunchBox =
            new(ProductCategories.Box, Vendor.ManyLoves.Id, "Lunch Box", "mlc-b-lun");

        #region Creation

        private Product(
            ProductCategories categories,
            Id vendorId,
            Name name,
            Sku sku,
            Description description = default,
            Size size = default,
            Id id = default
        ) : base(id)
        {
            Categories = categories;
            VendorId = vendorId;
            Description = description;
            Name = name;
            Size = size;
            Sku = sku;
        }

        #endregion

        #region Public Interface

        public ProductCategories Categories { get; }
        public Description Description { get; }
        public Name Name { get; }
        public Size Size { get; }
        public Sku Sku { get; }
        public Id VendorId { get; }

        #endregion

        #region Static Interface

        public static Sku GenerateSku(
            Token vendorToken,
            Token categoryToken,
            Token productToken,
            Token sizeToken = default
        )
        {
            var sku = vendorToken + "-" + categoryToken + "-" + productToken;
            sku += sizeToken is null ? "" : "-" + sizeToken;
            return sku;
        }

        #endregion
    }
}
