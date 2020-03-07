using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;

namespace InstaCounter.Data
{
    public class Fetcher
    {
        HttpClient client = new HttpClient();
        public Fetcher()
        {
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SetBaseUrl(string baseurl)
        {
            client.BaseAddress = new Uri(baseurl);
        }

        public string Get(string username)
        {
            HttpResponseMessage response = client.GetAsync(username).Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsStringAsync().Result; //Make sure to add a reference to System.Net.Http.Formatting.dll
                return dataObjects;
            }

            return "ERROR";
        }

        public void Dispose()
        {
            client.Dispose();

        }
    }
}