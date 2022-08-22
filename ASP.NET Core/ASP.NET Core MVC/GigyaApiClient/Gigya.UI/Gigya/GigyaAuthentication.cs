using Gigya.Common;
using Gigya.Process.Abstract;
using Gigya.Process.Concrete;
using Gigya.Process.Model;
using Gigya.Service.Abstract;
using Gigya.Service.Concrete;

class GigyaAuthentication
{
    private readonly AppSettings appSetting;

    public GigyaAuthentication()
    {
        appSetting = new AppSettings();
    }

    public UserSignatureValidationResult Login(string gigyaId, string idToken)
    {
        UserSignatureValidationResult userSignatureValidation = null;        
        IGigyaService gigService = new GigyaService();
        
        if (!string.IsNullOrWhiteSpace(gigyaId) && !string.IsNullOrWhiteSpace(idToken))
        {
            userSignatureValidation = gigService.ValidateUserSignature(
             new LoggedUser()
             {
                 UID = gigyaId,
                 IdToken = idToken
             });
        }

        if (userSignatureValidation != null)
        {
            _ = userSignatureValidation.IsLoggedIn;

            if (userSignatureValidation.StatusCode == Constants.GigyaStatusCodeSuccess)
            {
                IUserService usrService = new UserService();
                UserProfile usrProfile = usrService.GetUserProfile(gigyaId);

                if (usrProfile != null)
                {
                    _ = usrProfile.Profile.Email;

                    string name = string.Empty;

                    if (!string.IsNullOrWhiteSpace(usrProfile.Profile.FirstName))
                    {
                        name = usrProfile.Profile.FirstName;
                    }

                    if (!string.IsNullOrWhiteSpace(usrProfile.Profile.LastName))
                    {
                        name += " " + usrProfile.Profile.LastName;
                    }

                    if (name.Trim() != string.Empty)
                    {
                        _ = name.Trim();
                    }

                    if (!string.IsNullOrWhiteSpace(usrProfile.Data.MobilePhone))
                    {
                        _ = usrProfile.Data.MobilePhone;
                    }
                }
            }
        }

        return userSignatureValidation;
    }

    public LogoutResponse Logout(string gigyaId)
    {
        // accounts.logout
        // https://developers.gigya.com/display/GD/accounts.logout+REST

        GigyaService gigService = new GigyaService();
        LogoutResponse logResponse = gigService.Get<LogoutResponse>("UID", gigyaId, appSetting.GigyaSettings.GigyaAccountsLogout);

        if(logResponse != null && logResponse.ErrorCode == Constants.GigyaStatusCodeSuccess)
        {
            _ = logResponse.LogoutActiveSession;
        }

        return logResponse;
    }
}
