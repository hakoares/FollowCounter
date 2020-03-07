using System;
using System.Collections.Generic;
using InstaCounter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InstaCounter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetInstaDataController : ControllerBase
    {
        private static readonly string[] Usernames = new[]
        {
            "unglandsmote", "idaperny", "lisaborud", "hakonareskjold", "itro.no"
        };

        private readonly ILogger<GetInstaDataController> _logger;

        public GetInstaDataController(ILogger<GetInstaDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IList<Account> Get()
        {
            Fetcher fetcher = new Fetcher();
            fetcher.SetBaseUrl("http://46.101.178.129/user/");

            IList<Account> listOfUsers = new List<Account>();
            foreach (var user in Usernames)
            {
                var data = fetcher.Get(user);
                Account account = JsonConvert.DeserializeObject<Account>(data);
                listOfUsers.Add(account);
                Console.WriteLine(account.ToString());
            }

            fetcher.Dispose();
            return listOfUsers;

        }
    }
}