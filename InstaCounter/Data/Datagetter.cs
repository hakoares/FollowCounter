using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using InstaCounter.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace InstaCounter.Data
{
    public class Datagetter
    {
        private readonly ApiSettings _apiSettings;

        public Datagetter(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public void Start(IList<Account> accounts)
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);
            
            
            
            var timer = new System.Threading.Timer((e) =>
            {
                Fetcher fetcher = new Fetcher(_apiSettings, accounts);
                
                
            }, null, startTimeSpan, periodTimeSpan);
        }
    }
}