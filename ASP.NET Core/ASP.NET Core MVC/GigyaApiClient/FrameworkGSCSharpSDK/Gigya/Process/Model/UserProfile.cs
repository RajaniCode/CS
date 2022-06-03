using Newtonsoft.Json;
using System.Collections.Generic;

namespace Gigya.Process.Model
{
    public class UserProfile
    {
        private Organisation org;
        public string UID { set; get; }
        public GigyaUserProfile Profile { set; get; }
        public GigyaData Data { set; get; }
        public bool IsActive { set; get; }
        public bool IsRegistered { set; get; }
        public bool IsVerified { set; get; }
        public string QualificationType { set; get; }
        public string CustomerID { set; get; }       
        public Organisation Organization
        {
            get
            {
                if (Data == null || Profile == null)
                {
                    return null;
                }

                if (org != null)
                {
                    // From Gigya Organisation (using oid)
                    return org;
                }

                // Organisation from Profile
                return new Organisation
                {
                    Id = Data.OrganizationID ?? string.Empty,
                    AddressLine1 = Profile.Address ?? string.Empty,
                    AddressLine2 = string.Empty,
                    City = Profile.City,
                    Country = Profile.Country,
                    ProvinceCode = Data.ProvinceCode,
                    RegionCode = Data.RegionCode,
                    Zip = Profile.Zip,
                    BusinessClass = Data.BusinessClass,
                    BusinessName = Data.BusinessName,
                    BusinessPhoneNumber = string.Empty,
                    PostalCode = Profile.Zip,
                    Oid = Data.Oid
                };
            }
            set
            {
                org = value;
            }
        }

        //{
        //  "callId": "6820c85f125d4413a1fe8bc4b38343a1",
        //  "errorCode": 0,
        //  "apiVersion": 2,
        //  "statusCode": 200,
        //  "statusReason": "OK",
        //  "time": "2020-11-09T20:52:48.084Z",
        //  "UID": "165318",
        //  "created": "2017-11-06T12:21:13.000Z",
        //  "createdTimestamp": 1509970873,
        //  "data": {
        //    "primarySpecies": "BEEF",
        //    "prefix": "DR",
        //    "hybrisSubscription": "HYBRIS",
        //    "businessName": "Happy Hens Egg Farms",
        //    "isVetsAustraliaSubscribed": false,
        //    "starProgramSubscription": "",
        //    "isH4HSubscribed": false,
        //    "province": "",
        //    "terms": true,
        //    "pawClubSubscription": "",
        //    "mobile_phone": "(03) 5286 1400",
        //    "sapCustomerId": "2000034261",
        //    "isFarmPlannerSubscribed": true,
        //    "isPortalSubscribed": false,
        //    "isHybrisSubscribed": true,
        //    "isPawClubSubscribed": false,
        //    "crmContactId": "",
        //    "healthForHorsesSubscription": "",
        //    "cultureCode": "en_AU",
        //    "isEmployee": true,
        //    "billpaySubscription": "",
        //    "subscribe": false,
        //    "privacyPolicy": "Y",
        //    "businessClass": "",
        //    "contactTypes": {
        //      "contactType1": "phone",
        //      "contactType2": "office",
        //      "contactType3": "fax"
        //    },
        //    "userId": "165318",
        //    "isStarProgramSubscribed": false,
        //    "organizationID": "42105",
        //    "dmrId": "7000034261",
        //    "crmAccountId": "A-0000648425",
        //    "gigyaImportJobId": "b3484dda314944ce8901e82d0321ea34",
        //    "farmPlannerSubscription": "FARM_PLANNER",
        //    "isBillpaySubscribed": false,
        //    "vetsAustraliaSubscription": "",
        //    "customerID": "167270",
        //    "businessType": "FARM",
        //    "contactValues": {
        //      "contactValue1": "123456789"
        //    }
        //  },
        //  "subscriptions": {},
        //  "preferences": {},
        //  "isActive": true,
        //  "isRegistered": true,
        //  "isVerified": false,
        //  "lastLogin": "2020-11-09T20:51:51.923Z",
        //  "lastLoginTimestamp": 1604955111,
        //  "lastUpdated": "2020-09-15T14:35:39.053Z",
        //  "lastUpdatedTimestamp": 1600180539053,
        //  "loginProvider": "site",
        //  "oldestDataUpdated": "2020-06-17T15:46:31.078Z",
        //  "oldestDataUpdatedTimestamp": 1592408791078,
        //  "profile": {
        //    "firstName": "test",
        //    "lastName": "Last",
        //    "city": "MEREDITH",
        //    "country": "AU",
        //    "email": "efk08460@sqoai.com",
        //    "zip": "3333",
        //    "oidcData": {
        //      "updated_at": "2019-10-09T22:08:16Z"
        //    }
        //  },
        //  "socialProviders": "site"
        //}
    }

    public class ProfileResults
    {
        [JsonProperty("apiVersion")]
        public int ApiVersion { get; set; }

        [JsonProperty("callId")]
        public string CallId { get; set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }

        [JsonProperty("statusReason")]
        public string StatusReason { get; set; }

        [JsonProperty("results")]
        public List<UserProfile> Results { get; set; }
    }
}
