// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;

namespace Gigya.Process.Model
{
    public class GigyaData
    {
        [JsonProperty("primarySpecies")]
        public string PrimarySpecies { set; get; }

        [JsonProperty("isEmployee")]
        public bool IsEmployee { set; get; }

        [JsonProperty("businessClass")]
        public string BusinessClass { set; get; }

        [JsonProperty("businessName")]
        public string BusinessName { set; get; }

        [JsonProperty("businessType")]
        public string BusinessType { set; get; }

        [JsonProperty("mobilePhone")]
        public string MobilePhone { set; get; }

        [JsonProperty("organizationID")]
        public string OrganizationID { set; get; }

        [JsonProperty("regionCode")]
        public string RegionCode { set; get; }

        [JsonProperty("provinceCode")]
        public string ProvinceCode { set; get; }

        [JsonProperty("selectvacSubscription")]
        public string SelectvacSubscription { set; get; }

        [JsonProperty("subscriptionStatus")]
        public string SubscriptionStatus { set; get; }

        [JsonProperty("qualificationType")]
        public string QualificationType { set; get; }

        [JsonProperty("endDate")]
        public string EndDate { set; get; }

        [JsonProperty("accessCode")]
        public string AccessCode { set; get; }

        [JsonProperty("prefix")]

        public string Prefix { get; set; }

        [JsonProperty("oid")]
        public string Oid { set; get; }

        [JsonProperty("contactTypes")]
        public ContactType ContactTypes { set; get; }

        [JsonProperty("contactValues")]
        public ContactValue ContactValues { set; get; }
    }
}
