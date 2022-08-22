// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;

namespace Gigya.Process.Model
{
    public class GigyaOrganizationData
    {
        [JsonProperty("data")]
        public Organisation Data { set; get; }
    }
}
