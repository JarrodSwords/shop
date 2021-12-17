using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure;

namespace Shop.Api.Spec
{
    public class TestWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {
        #region Protected Interface

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("IntegrationTesting");

            builder.ConfigureServices(
                services =>
                {
                    using var scope = services.BuildServiceProvider().CreateScope();

                    services.AddDbContext<Context>(
                        o => { o.UseSqlServer("Write"); }
                    );

                    var context = scope.ServiceProvider.GetRequiredService<Context>();

                    //context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    //context.Database.Migrate();
                }
            );
        }

        #endregion
    }
}
