using System;
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

    public void Login(string gigyaId , string idToken)
    {
        IGigyaService gigService = new GigyaService();
        
        if (!string.IsNullOrWhiteSpace(gigyaId) && !string.IsNullOrWhiteSpace(idToken))
        {
            var userSignatureValidation = gigService.ValidateUserSignature
            (
                 new LoggedUser()
                 {
                     UID = gigyaId,
                     IdToken = idToken
                 }
            );

            if (userSignatureValidation != null)
            {
                if (userSignatureValidation.StatusCode == Constants.GigyaStatusCodeSuccess)
                {
                    Console.WriteLine($"IsLoggedIn: {userSignatureValidation.IsLoggedIn}");

                    IUserService usrService = new UserService();
                    UserProfile usrProfile = usrService.GetUserProfile(gigyaId);

                    if (usrProfile != null)
                    {
                        Console.WriteLine($"Email: {usrProfile.Profile.Email}");

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
                            Console.WriteLine($"Name: {name.Trim()}");
                        }

                        if (!string.IsNullOrWhiteSpace(usrProfile.Data.MobilePhone))
                        {
                            Console.WriteLine($"Mobile Phone: {usrProfile.Data.MobilePhone}");
                        }

                        Console.WriteLine();
                    }
                }
            }
        }      
    }

    public void Logout(string gigyaId)
    {
        // accounts.logout
        // https://developers.gigya.com/display/GD/accounts.logout+REST

        GigyaService gigService = new GigyaService();
        LogoutResponse logResponse = gigService.Get<LogoutResponse>("UID", gigyaId, appSetting.GigyaSettings.GigyaAccountsLogout);

        if(logResponse != null && logResponse.ErrorCode == Constants.GigyaStatusCodeSuccess)
        {
            Console.WriteLine($"LogoutActiveSession: {logResponse.LogoutActiveSession}");
        }

        Console.WriteLine();
    }
}

