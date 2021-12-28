using System;

namespace Shop.Write
{
    public partial class Company : Entity
    {
        #region Creation

        public Company(Guid id) : base(id)
        {
        }

        #endregion

        #region Public Interface

        public string Name { get; set; }
        public string SkuToken { get; set; }

        #endregion
    }
}
