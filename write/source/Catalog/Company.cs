namespace Shop.Write
{
    public partial class Company
    {
        #region Creation

        private Company(Shop.Catalog.Company source) : base(source.Id)
        {
            Name = source.Name;
            SkuToken = source.SkuToken;
        }

        #endregion

        #region Static Interface

        public static implicit operator Company(Shop.Catalog.Company source) => new(source);

        #endregion
    }
}
