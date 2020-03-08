using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using InstaCounter.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace InstaCounter.Data
{
    public class Fetcher
    {
        
    private static RestClient _client = new RestClient();
    private static string _authorization;
    private readonly ApiSettings _apiSettings;
    private readonly AccountService _accountService;


    public Fetcher(ApiSettings apiSettings, IList<Account> accounts, AccountService accountService)
    {
        _apiSettings = apiSettings;
        _accountService = accountService;

        if (_authorization == null)
        {
            GetAccessToken();
        }

        foreach (var account in accounts)
        {
            Get(account);
        }
        
    }

    private void GetAccessToken()
    {
        _client = new RestClient(_apiSettings.token_url);
        var request = new RestRequest(Method.POST);
        request.AddHeader("content-type", "application/json");
        request.AddParameter("application/json",
            "{\"client_id\":\"" + _apiSettings.client_id + "\",\"client_secret\":\"" + _apiSettings.client_secret + "\",\"audience\":\"" + _apiSettings.audience + "\",\"grant_type\":\"client_credentials\"}",
            ParameterType.RequestBody);
        IRestResponse response = _client.Execute(request);

        dynamic data = JObject.Parse(response.Content);
        _authorization = data.token_type + " " + data.access_token;
    }
    
    
    private async void Get (Account account)
    {
        _client = new RestClient("http://46.101.178.129/");
        IRestRequest request;
        
        switch (account.Medium)
        {
            case Medium.TIKTOK:
                request = new RestRequest("tt/{username}", Method.GET)
                    .AddParameter("username", account.Username, ParameterType.UrlSegment);
                break;

            case Medium.INSTAGRAM:
                request = new RestRequest("ig/{username}", Method.GET)
                    .AddParameter("username", account.Username, ParameterType.UrlSegment);
                break;

            default:
                request = new RestRequest();
                break;
        }

        request.AddHeader("authorization", _authorization);

        var res =  await _client.ExecuteAsync(request);
        
        
        
        dynamic data = JObject.Parse(res.Content);

        int count = Convert.ToInt32(data.followers);

        var newMeasurement = new Measurement(count);    
        var user = _accountService.Get(account.Username);
        
        if (user == null)
        {
            _accountService.Create(account);
            user = _accountService.Get(account.Username);

        }
        
        user.Measurements.Add(newMeasurement);
        _accountService.Update(user);
        Console.WriteLine("IG: " + JsonConvert.SerializeObject(_accountService.Get(Medium.INSTAGRAM)));
        Console.WriteLine("TT: " + JsonConvert.SerializeObject(_accountService.Get(Medium.TIKTOK)));
    }

    }
}