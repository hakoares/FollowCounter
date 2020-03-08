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
        private readonly ApiSettings _apiSettings;

        public GetInstaDataController(ILogger<GetInstaDataController> logger, ApiSettings apiSettings)
        {
            _logger = logger;
            _apiSettings = apiSettings;
        }

        [HttpGet]
        public void Get()
        {
            Datagetter datagetter = new Datagetter(_apiSettings);   
            
            var a1 = new Account("hakonareskjold", Medium.INSTAGRAM);
            var a2 = new Account("lasselom", Medium.INSTAGRAM);
            
            IList<Account> list = new List<Account>();
            
            list.Add(a1);
            datagetter.Start(list);
        }
    }
}