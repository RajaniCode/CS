using System;
// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;

namespace Gigya.Process.Model
{
    public class GigyaResponse
    {
        [JsonProperty("errorCode")]
        public int ErrorCode { set; get; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { set; get; }

        [JsonProperty("callId")]
        public string CallId { set; get; }

        [JsonProperty("time")]
        public DateTime Time { set; get; }
    }
}
