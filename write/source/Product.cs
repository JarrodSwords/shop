using System;
using Shop.Shared;

namespace Shop.Write
{
    public partial class Product : Entity
    {
        #region Creation

        public Product(Guid id) : base(id)
        {
        }

        #endregion

        #region Public Interface

        public string Description { get; set; }
        public bool IsBox { get; set; }
        public bool IsDessert { get; set; }
        public bool IsSide { get; set; }
        public string Name { get; set; }
        public ushort? Size { get; set; }
        public string Sku { get; set; }
        public Guid VendorId { get; set; }

        public ProductCategories GetCategories()
        {
            var categories = ProductCategories.None;

            if (IsBox)
                categories |= ProductCategories.Box;

            if (IsDessert)
                categories |= ProductCategories.Dessert;

            if (IsSide)
                categories |= ProductCategories.Side;

            return categories;
        }

        public Product SetCategories(ProductCategories categories)
        {
            IsBox = categories.HasFlag(ProductCategories.Box);
            IsDessert = categories.HasFlag(ProductCategories.Dessert);
            IsSide = categories.HasFlag(ProductCategories.Side);
            return this;
        }

        #endregion
    }
}
