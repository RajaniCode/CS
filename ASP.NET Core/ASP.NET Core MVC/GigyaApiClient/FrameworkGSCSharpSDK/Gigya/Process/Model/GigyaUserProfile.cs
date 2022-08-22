// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;

namespace Gigya.Process.Model
{
    public class GigyaUserProfile
    {
        [JsonProperty("firstName")]
        public string FirstName { set; get; }

        [JsonProperty("lastName")]
        public string LastName { set; get; }

        [JsonProperty("address")]
        public string Address { set; get; }

        [JsonProperty("city")]
        public string City { set; get; }

        [JsonProperty("country")]
        public string Country { set; get; }

        [JsonProperty("email")]
        public string Email { set; get; }

        [JsonProperty("zip")]
        public string Zip { set; get; }
    }
}
