using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Shop.Catalog.Services
{
    public class AutofacModule : Module
    {
        private readonly Assembly _assembly = typeof(AutofacModule).Assembly;

        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(_assembly)
                .AsImplementedInterfaces();
        }

        #endregion
    }
}
