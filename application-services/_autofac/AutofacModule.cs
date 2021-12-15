using Autofac;

namespace Shop.ApplicationServices._autofac
{
    public class AutofacModule : Module
    {
        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(AutofacModule).Assembly)

                //.Where(x => x.Name.EndsWith("Command"))
                .AsImplementedInterfaces();
        }

        #endregion
    }
}
