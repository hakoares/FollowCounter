using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
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


    public Fetcher(ApiSettings apiSettings)
    {
        _apiSettings = apiSettings;

        if (_authorization == null)
        {
            GetAccessToken();
        }
        
        Get("hakonareskjold", Medium.INSTAGRAM);
        Get("lasselom", Medium.INSTAGRAM);
        Get("lasselom", Medium.TIKTOK);
        
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
    
    
    public static async void Get (string username, Medium medium)
    {
        _client = new RestClient("http://46.101.178.129/");
        IRestRequest request;
        
        switch (medium)
        {
            case Medium.TIKTOK:
                request = new RestRequest("tt/{username}", Method.GET)
                    .AddParameter("username", username, ParameterType.UrlSegment);
                break;

            case Medium.INSTAGRAM:
                request = new RestRequest("ig/{username}", Method.GET)
                    .AddParameter("username", username, ParameterType.UrlSegment);
                break;

            default:
                request = new RestRequest();
                break;
        }

        request.AddHeader("authorization", _authorization);

        var res =  await _client.ExecuteAsync(request);
        
        // WRITE TO DATABASE
        Console.Write(res.Content);

    }

    }
}