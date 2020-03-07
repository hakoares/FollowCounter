using Newtonsoft.Json;

namespace InstaCounter
{
    public class ApiSettings
    {
        public string token_url { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string audience { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}