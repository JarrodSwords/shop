using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Shop.Api
{
    public class Program
    {
        #region Static Interface

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        #endregion
    }
}
