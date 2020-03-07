using System;
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

        public void Start()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);
            
            
            var timer = new System.Threading.Timer((e) =>
            {
                Console.WriteLine("KJØR");
                Fetcher fetcher = new Fetcher(_apiSettings);
                
                
            }, null, startTimeSpan, periodTimeSpan);
        }
    }
}