using Autofac;

namespace Shop.Read
{
    public class AutofacModule : Module
    {
        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(AutofacModule).Assembly)
                .AsImplementedInterfaces();
        }

        #endregion
    }
}
