// Install-Package Newtonsoft.Json -Version 12.0.3
using Newtonsoft.Json;

namespace Gigya.Process.Model
{
    public class LogoutResponse : GigyaResponse
    {
        [JsonProperty("logoutActiveSession")]
        public string LogoutActiveSession { set; get; }
    }
}