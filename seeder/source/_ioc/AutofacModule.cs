using Autofac;

namespace Shop.Seeder
{
    public class AutofacModule : Module
    {
        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SeedingApp>().AsSelf();
            builder.RegisterContext();
        }

        #endregion
    }
}
