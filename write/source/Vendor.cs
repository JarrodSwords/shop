using System;

namespace Shop.Write
{
    public partial class Vendor : Entity
    {
        #region Creation

        public Vendor(Guid id) : base(id)
        {
        }

        #endregion

        #region Public Interface

        public string Name { get; set; }
        public string SkuToken { get; set; }

        #endregion
    }
}
