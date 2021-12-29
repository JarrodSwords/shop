using Jgs.Cqrs;

namespace Shop.Catalog.Services
{
    public record SeedCatalog : ICommand
    {
        public class Handler : Handler<SeedCatalog>
        {
            #region Creation

            public Handler(IUnitOfWork uow) : base(uow)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(SeedCatalog args)
            {
                Uow.Companies.Create(Company.ManyLoves);

                Uow.Commit();
            }

            #endregion
        }
    }
}
