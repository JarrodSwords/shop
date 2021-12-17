using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Shop.Infrastructure;

namespace Shop.Api
{
    public class Startup
    {
        #region Creation

        public Startup(IWebHostEnvironment environment)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
        }

        #endregion

        #region Public Interface

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "shop v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapHealthChecks("/healthcheck");
                    endpoints.MapControllers();
                }
            );
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks();
            services.AddSwaggerGen(
                c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "shop", Version = "v1" }); }
            );

            services.AddDbContext<Context>(
                o => { o.UseSqlServer(Configuration.GetConnectionString("Shop")); }
            );
        }

        #endregion
    }
}
