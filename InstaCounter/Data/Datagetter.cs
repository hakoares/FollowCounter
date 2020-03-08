using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using InstaCounter.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace InstaCounter.Data
{
    public class Datagetter
    {

        public Datagetter()
        {
        }

        public void Start(IList<Account> accounts)
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);
            
            var apiSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build().GetSection("ApiSettings").Get<ApiSettings>();

            var accountServiceSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build().GetSection("InstaHistoryDatabaseSettings").Get<InstaHistoryDatabaseSettings>();

            
            var timer = new System.Threading.Timer((e) =>
            {
                
                Fetcher fetcher = new Fetcher(apiSettings, accounts, new AccountService(accountServiceSettings));
                
                
            }, null, startTimeSpan, periodTimeSpan);
        }
    }
}