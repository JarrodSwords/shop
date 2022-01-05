using System;

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
        public string Name { get; set; }
        public ushort? Size { get; set; }
        public string Sku { get; set; }
        public Guid VendorId { get; set; }

        #endregion
    }
}
