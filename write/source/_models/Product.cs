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

        public Guid CompanyId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }

        #endregion
    }
}
