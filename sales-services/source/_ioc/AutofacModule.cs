using System.Reflection;
using Autofac;
using Shop.Sales.Orders;
using Module = Autofac.Module;

namespace Shop.Sales.Services
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

            builder.RegisterType<Order.Builder>().AsSelf();
        }

        #endregion
    }
}
