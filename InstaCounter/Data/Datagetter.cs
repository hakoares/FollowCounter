using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using InstaCounter.Services;
using Newtonsoft.Json;

namespace InstaCounter.Data
{
    public class Datagetter
    {
        public Datagetter()
        {

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(2);
            
            
            var timer = new System.Threading.Timer((e) =>
            {

                
            }, null, startTimeSpan, periodTimeSpan);
        }
    }
}