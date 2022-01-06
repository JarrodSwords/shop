using System.Reflection;
using Autofac;
using Shop.Catalog.Services;
using Shop.Read.Sales;
using Shop.Sales.Services;
using Shop.Write;

namespace Shop.Api
{
    public static class ContainerBuilderExtensions
    {
        private static readonly Assembly[] Assemblies =
        {
            typeof(Context).Assembly,
            typeof(FindOrderHandler).Assembly,
            typeof(SubmitOrderHandler).Assembly,
            typeof(RegisterProductHandler).Assembly
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
