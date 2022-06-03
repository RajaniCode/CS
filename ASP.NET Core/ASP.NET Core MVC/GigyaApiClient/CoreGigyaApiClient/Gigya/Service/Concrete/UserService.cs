using System;
// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;
// namespace Gigya.Socialize.SDK in GigyaApiClient.csproj
using Gigya.Socialize.SDK;
using Gigya.Process.Model;
using Gigya.Service.Abstract;
using Gigya.Common;

namespace Gigya.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly AppSettings appSetting;

        public UserService()
        {
            appSetting = new AppSettings();
        }

        public UserProfile GetUserProfile(string gigyaId)
        {
            // ids.getAccountInfo
            // https://developers.gigya.com/display/GD/ids.getAccountInfo+REST
            GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaIdsGetAccountInfo, null, true, appSetting.GigyaSettings.GigyaUserKey);
            request.SetParam("UID", gigyaId);

            UserProfile profile = null;
            try
            {
                GSResponse response = request.Send();

                if (response != null)
                {
                    if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
                    {
                        // profile = JsonConvert.DeserializeObject<UserProfile>(response.GetData().ToJsonString());
                        profile = JsonConvert.DeserializeObject<UserProfile>(response.GetResponseText());
                        if (profile != null && profile.Data != null)
                        {
                            if (!string.IsNullOrEmpty(profile.Data.Oid))
                            {
                                // Get Gigya organization 
                                // profile.Organization = GetOrganisation(profile.Data.Oid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var log = ex.ToString();
                // throw;
            }

            return profile;
        }
    }
}
