using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaCounter.Data;
using InstaCounter.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            Datagetter datagetter = new Datagetter();
            var a1 = new Account("hakonareskjold", Medium.INSTAGRAM);
            var a2 = new Account("lasselom", Medium.INSTAGRAM);
            var a3 = new Account("lasselom", Medium.TIKTOK);
            
            IList<Account> list = new List<Account>();
            
            list.Add(a1);
            list.Add(a2);
            list.Add(a3);
            datagetter.Start(list);            
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}