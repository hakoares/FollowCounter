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
    static RestClient client = new RestClient();
    private static string authorization;
    static ArrayList list = new ArrayList();
    
    public Fetcher()
    {

        client = new RestClient("https://dev-oy927gtz.eu.auth0.com/oauth/token");
        var request = new RestRequest(Method.POST);
        request.AddHeader("content-type", "application/json");
        request.AddParameter("application/json",
            "{\"client_id\":\"0bdvIDUL2x8qWjXX0Zzda628uBtWXmif\",\"client_secret\":\"f43hGMDf4LWJaP_F3l4VEXPgnh9nZ8iL8Dxv2IeoFBOGKNBo9BIy_JcaOsVQaVLX\",\"audience\":\"http://46.101.178.129/\",\"grant_type\":\"client_credentials\"}",
            ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);

        dynamic data = JObject.Parse(response.Content);
        authorization = data.token_type + " " + data.access_token;
        client = new RestClient("http://46.101.178.129/");

        Get("hakonareskjold", Medium.INSTAGRAM);
        Get("lasselom", Medium.INSTAGRAM);
        Get("lasselom", Medium.TIKTOK);
        
    }

    
    public void SetBaseUrl(string baseurl)
    {
        client.BaseUrl = new Uri(baseurl);
    }

    
    private static async void Get (string username, Medium medium)
    {
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

        request.AddHeader("authorization", authorization);

        Console.WriteLine("PRE EXECUTE");
        var res =  await client.ExecuteAsync(request);
        Console.WriteLine(res.Content);


        list.Add(res);
    }

    }
}