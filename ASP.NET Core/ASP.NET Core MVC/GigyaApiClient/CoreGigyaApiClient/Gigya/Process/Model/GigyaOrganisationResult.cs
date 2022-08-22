using System.Collections.Generic;
// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;

namespace Gigya.Process.Model
{
    public class GigyaOrganisationResult : GigyaResponse
    {
        [JsonProperty("results")]
        public List<GigyaOrganizationData> Results { set; get; }
    }
}
