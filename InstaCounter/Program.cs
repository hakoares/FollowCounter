using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaCounter.Data;
using InstaCounter.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InstaCounter
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Datagetter datagetter = new Datagetter();
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}