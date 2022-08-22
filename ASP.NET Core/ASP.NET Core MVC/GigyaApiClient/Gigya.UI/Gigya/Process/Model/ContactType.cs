// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;

namespace Gigya.Process.Model
{
    public class ContactType
    {
        [JsonProperty("contactType1")]
        public string ContactType1 { set; get; }

        [JsonProperty("contactType2")]
        public string ContactType2 { set; get; }

        [JsonProperty("contactType3")]
        public string ContactType3 { set; get; }
    }
}
