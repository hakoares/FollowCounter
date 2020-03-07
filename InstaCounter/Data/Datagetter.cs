using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using InstaCounter.Services;
using Newtonsoft.Json;

namespace InstaCounter.Data
{
    public class Datagetter
    {
        private readonly AccountService _accountService;
        public Datagetter()
        {
            string[] Usernames = new[]
            {
                "mittnorge", "mittnordnorge", "lasselom"
            };

            foreach (var user in Usernames)
            {
                var a = new Account();
                a.Measurements = new Collection<Measurement>();
                a.Username = user;
                Console.WriteLine(JsonConvert.SerializeObject(a));

            }
            

            
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);
            
            
            var timer = new System.Threading.Timer((e) =>
            {

                Fetcher fetcher = new Fetcher();
                fetcher.SetBaseUrl("http://46.101.178.129/user/");

                IList<Account> listOfUsers = new List<Account>();
                foreach (var user in Usernames)
                {
                    var data = fetcher.Get(user);
                    ApiModel apiModel = JsonConvert.DeserializeObject<ApiModel>(data);
                    var a = new Account();
                    a.Username = apiModel.Username;
                    a.Measurements.Add(new Measurement(apiModel.Followers));
                    Console.WriteLine(JsonConvert.SerializeObject(a));
                }

                fetcher.Dispose();
                
            }, null, startTimeSpan, periodTimeSpan);
        }
    }
}