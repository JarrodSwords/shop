using System.Reflection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Shop.Catalog;
using Shop.Read.Sales;
using Shop.Sales.Services;
using Shop.Write;

namespace Shop.Seeder
{
    public static class ContainerBuilderExtensions
    {
        private static readonly Assembly[] Assemblies =
        {
            typeof(Program).Assembly,
            typeof(SubmitOrder).Assembly,
            typeof(FindOrderHandler).Assembly,
            typeof(RegisterProduct).Assembly,
            typeof(Context).Assembly
        };

        #region Static Interface

        public static ContainerBuilder RegisterAssemblyModules(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(Assemblies);
            return builder;
        }

        public static ContainerBuilder RegisterContext(this ContainerBuilder builder)
        {
            var b = new DbContextOptionsBuilder<Context>();
            b.UseSqlServer(
                "Data Source=BECKY\\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True;Connect Timeout=60;"
            );

            builder.RegisterType<Context>()
                .WithParameter(
                    "options",
                    b.Options
                );

            return builder;
        }

        #endregion
    }
}
