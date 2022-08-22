// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;

namespace Gigya.Process.Model
{
    public class ContactValue
    {
        [JsonProperty("contactValue1")]
        public string ContactValue1 { set; get; }

        [JsonProperty("contactValue2")]
        public string ContactValue2 { set; get; }

        [JsonProperty("contactValue3")]
        public string ContactValue3 { set; get; }
    }
}
