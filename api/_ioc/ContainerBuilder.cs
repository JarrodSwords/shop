using System.Reflection;
using Autofac;
using Shop.Infrastructure;
using Shop.Sales.Services;

namespace Shop.Api
{
    public static class ContainerBuilderExtensions
    {
        private static readonly Assembly[] Assemblies =
        {
            typeof(Context).Assembly,
            typeof(SubmitOrder).Assembly
        };

        #region Static Interface

        public static ContainerBuilder RegisterAssemblyModules(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(Assemblies);
            return builder;
        }

        #endregion
    }
}
