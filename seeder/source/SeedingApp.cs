using Jgs.Cqrs;
using Shop.Catalog.Services;

namespace Shop.Seeder
{
    public class SeedingApp
    {
        private readonly ICommandHandler<SeedCatalog> _seedCatalog;

        #region Creation

        public SeedingApp(ICommandHandler<SeedCatalog> seedCatalog)
        {
            _seedCatalog = seedCatalog;
        }

        #endregion

        #region Public Interface

        public void Run()
        {
            _seedCatalog.Handle(new());
        }

        #endregion
    }
}
