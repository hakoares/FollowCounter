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
        public void Get()
        {

        }
    }
}