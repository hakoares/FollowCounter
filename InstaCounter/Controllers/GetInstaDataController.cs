using System;
using System.Collections.Generic;
using InstaCounter.Data;
using InstaCounter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

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
        private readonly AccountService _accountService;

        
        public GetInstaDataController(ILogger<GetInstaDataController> logger, ApiSettings apiSettings, AccountService accountService)
        {
            _logger = logger;
            _apiSettings = apiSettings;
            _accountService = accountService;
        }

        [HttpGet]
        public void Get()
        {

            // var data = _accountService.Get();
            // Console.WriteLine(JsonConvert.SerializeObject(data));
            



        }
    }
}