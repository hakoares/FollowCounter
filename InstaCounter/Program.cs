using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaCounter.Data;
using InstaCounter.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InstaCounter
{
    public class Program
    {

        public static void Main(string[] args)
        {
            
            IServiceCollection services = new ServiceCollection();


            services.AddSingleton(pr => pr.GetService<Datagetter>());
            services.AddSingleton(
                provider => new Datagetter(provider.GetService<ApiSettings>())
            );
 
            var serviceProvider = services.BuildServiceProvider();
            var instance = serviceProvider.GetService<Datagetter>();
            instance.Start();
            
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}