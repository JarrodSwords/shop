using Autofac;

namespace Shop.Seeder
{
    public class Program
    {
        #region Static Interface

        private static void Main(string[] args)
        {
            using var scope = CreateScope();
            scope.Resolve<SeedingApp>().Run();
        }

        private static ILifetimeScope CreateScope() =>
            new ContainerBuilder()
                .RegisterAssemblyModules()
                .Build()
                .BeginLifetimeScope();

        #endregion
    }
}
