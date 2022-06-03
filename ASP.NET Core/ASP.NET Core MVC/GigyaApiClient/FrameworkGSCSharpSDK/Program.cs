using System;
using System.Collections.Generic;
using System.Linq;
// Install-Package Newtonsoft.Json -Version 12.0.3
using Newtonsoft.Json;
using Gigya.Socialize.SDK;
using Gigya.Common;
using Gigya.Model.Models;
using Gigya.Model.ViewModels;
using Gigya.Process.Abstract;
using Gigya.Process.Concrete;
using Gigya.Process.Model;

class Program
{
    private AppSettings appSetting;

    static void Main()
    {
        Program prgm = new Program();
        prgm.appSetting = new AppSettings();
        prgm.Gigya();

        Console.WriteLine("Press any key to close this window . . .");
        Console.ReadKey();
    }

    private void Gigya()
    {
        string gigyaId = "ae0ac8705e7c44f5a92ae94f9ea43cf8";
        string email = "rajani.somaskandan@meritgroup.co.uk"; // string password = "$W0rdf!$h";
        string idToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IlJFUTBNVVE1TjBOQ1JUSkVNemszTTBVMVJrTkRRMFUwUTBNMVJFRkJSamhETWpkRU5VRkJRZyIsImRjIjoidXMxIn0.eyJpc3MiOiJodHRwczovL2ZpZG0uZ2lneWEuY29tL2p3dC8zX25wbTU4Yy1pekF6UTVWclNQTl9JVnNJaWliYVQxNWV6X0VYZ1poa242dDZyMzNDenJDc3lsNER5MGxYTTgxZ2EvIiwic3ViIjoiYWUwYWM4NzA1ZTdjNDRmNWE5MmFlOTRmOWVhNDNjZjgiLCJpYXQiOjE2MDkzNzA5NzAsImV4cCI6MTYwOTM3MTAzMCwiaXNMb2dnZWRJbiI6dHJ1ZX0.YDyEI-szvvikPlLUy4J4zfXAgd09_Q6ubAMjItzafXpMLu40MiX7MpHOUkb8jKZhHHNDu8Vv-5hxK6ODhFr_v4bD62xw5_XvggAULouN3Kgr19t3D5CoIobvD0HholfH2ZKeu_cYBIZwEjfeLdNq4yYOjtP135GDcT9js5bW37Sa1tgd7pzTeEb1L4z3ZYh5fTBpcPjnIG3zr_Jn8HRymA5VQcLyxnAdtIb7cTN-myUywCHk4mAfuGTTZQLD_QC-fHXbQ8QvprvJMZMEXd3WhAKwCyEBlFR9eJzXJIJrjApV6eOQSQRSca3cHRSwJ2srLryobNbVI7XeYyTUvd5PVg";

        GigyaAuthentication gigAuthentication = new GigyaAuthentication();
        gigAuthentication.Login(gigyaId, idToken);
        gigAuthentication.Logout(gigyaId);

        GetUserProfileByGigyaId(gigyaId);
        GetUserProfileExtraByGigyaId(gigyaId);
        GetUserProfileByEmail(email);

        UserProfile profile = GetAccountInfoByGigyaId(gigyaId);
        profile.Profile.Country = profile.Profile.Country == "US" ? "USA" : "US";
        SetAccountInfo(profile);
        profile = GetAccountInfoByGigyaId(gigyaId);

        email = $"email{Guid.NewGuid()}@example.com";
        string password = GenerateRandomPassword();
        string regToken = Register(email, password);
        profile = GetAccountInfoRegToken(regToken);
        DeleteProfile(profile.UID);

        email = $"prospect{Guid.NewGuid()}@example.com";
        password = GenerateRandomPassword();
        RancherDetails rancher = GetRancherDetails(email);
        string oid = Guid.NewGuid().ToString();
        ProspectUserRegistration prospectUser = GetProspectUser(rancher, password, oid);
        regToken = Register(prospectUser);
        profile = GetAccountInfoRegToken(regToken);

        DeleteProfile(profile.UID);

        email = "rajani.somaskandan@proagrica.com";
        ProspectUserResetPassword(email);
    }

    public void GetUserProfileByEmail(string email)
    {
        GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaProspectApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaIdsSearch, null, true, appSetting.GigyaSettings.GigyaUserKey);
        request.SetParam("query", $"SELECT * FROM emailAccounts WHERE profile.email = '{email}'");

        try
        {
            GSResponse response = request.Send();

            if (response != null)
            {
                Console.WriteLine("ids.search:");
                Console.WriteLine("ids.search: Response Error Code:");
                Console.WriteLine(response.GetErrorCode());
                // Console.WriteLine("ids.search: Response Data JSON String:");
                // Console.WriteLine(response.GetData().ToJsonString());
                Console.WriteLine("ids.search: Response Text:");
                Console.WriteLine(response.GetResponseText());

                if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
                {
                    ProfileResults profileResults = JsonConvert.DeserializeObject<ProfileResults>(response.GetData().ToJsonString());
                    // ProfileResults profileResults = JsonConvert.DeserializeObject<ProfileResults>(response.GetResponseText());
                    UserProfile usrProfile = new UserProfile();
                    if (profileResults != null && profileResults.Results != null)
                    {
                        usrProfile.Data = profileResults.Results?.FirstOrDefault()?.Data;
                        usrProfile.Profile = profileResults.Results?.FirstOrDefault()?.Profile;
                        usrProfile.Organization = profileResults.Results?.FirstOrDefault()?.Organization;
                        // usrProfile.Organization = GetOrganisationDataStore((profileResults.Results?.FirstOrDefault()?.Organization).Oid).Results?.FirstOrDefault()?.Data;
                    }
                }
                else
                {
                    Console.WriteLine("ids.search: Response Error Message:");
                    Console.WriteLine(response.GetErrorMessage());
                    Console.WriteLine($"ids.search: Response Error:{response.GetLog()}");
                }
            }
        }
        catch (Exception ex)
        {
            var log = ex.ToString();
            Console.WriteLine(log);
            // throw;
        }

        Console.WriteLine();
    }

    public void GetUserProfileByGigyaId(string gigyaId)
    {
        // ids.getAccountInfo
        // https://developers.gigya.com/display/GD/ids.getAccountInfo+REST
        GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaIdsGetAccountInfo, null, true, appSetting.GigyaSettings.GigyaUserKey);
        request.SetParam("UID", gigyaId);

        try
        {
            GSResponse response = request.Send();

            if (response != null)
            {
                Console.WriteLine("ids.getAccountInfo:");
                Console.WriteLine("ids.getAccountInfo: Response Error Code:");
                Console.WriteLine(response.GetErrorCode());
                // Console.WriteLine("ids.getAccountInfo: Response Data JSON String:");
                // Console.WriteLine(response.GetData().ToJsonString());
                Console.WriteLine("ids.getAccountInfo: Response Text:");
                Console.WriteLine(response.GetResponseText());

                if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
                {
                    UserProfile profile = JsonConvert.DeserializeObject<UserProfile>(response.GetData().ToJsonString());
                    // UserProfile profile = JsonConvert.DeserializeObject<UserProfile>(response.GetResponseText());
                    if (profile != null && profile.Data != null)
                    {
                        if (!string.IsNullOrEmpty(profile.Data.Oid))
                        {
                            // Get Gigya organization 
                            profile.Organization = GetOrganisationDataStore(profile.Data.Oid).Results?.FirstOrDefault()?.Data;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ids.getAccountInfo: Response Error Message:");
                    Console.WriteLine(response.GetErrorMessage());
                    Console.WriteLine($"ids.getAccountInfo: Response Error:{response.GetLog()}");
                }
            }
        }
        catch (Exception ex)
        {
            var log = ex.ToString();
            Console.WriteLine(log);
            // throw;
        }

        Console.WriteLine();
    }

    public void GetUserProfileExtraByGigyaId(string gigyaId)
    {
        // ids.getAccountInfo
        // https://developers.gigya.com/display/GD/ids.getAccountInfo+REST
        GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaIdsGetAccountInfo, null, true, appSetting.GigyaSettings.GigyaUserKey);
        request.SetParam("UID", gigyaId);
        request.SetParam("extraProfileFields", "address,phones");
        request.SetParam("include", "emails,profile,data,isLockedOut"); // isLockedOut ?

        try
        {
            GSResponse response = request.Send();

            if (response != null)
            {
                Console.WriteLine("ids.getAccountInfo:");
                Console.WriteLine("ids.getAccountInfo: Response Error Code:");
                Console.WriteLine(response.GetErrorCode());
                // Console.WriteLine("ids.getAccountInfo: Response Data JSON String:");
                // Console.WriteLine(response.GetData().ToJsonString());
                Console.WriteLine("ids.getAccountInfo: Response Text:");
                Console.WriteLine(response.GetResponseText());

                if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
                {
                    // UserProfile profile = JsonConvert.DeserializeObject<UserProfile>(response.GetData().ToJsonString());
                    UserProfile profile = JsonConvert.DeserializeObject<UserProfile>(response.GetResponseText());
                    if (profile != null && profile.Data != null)
                    {
                        if (!string.IsNullOrEmpty(profile.Data.Oid))
                        {
                            // Get Gigya organization 
                            // profile.Organization = GetOrganisation(profile.Data.Oid);
                            profile.Organization = GetOrganisationDataStore(profile.Data.Oid).Results?.FirstOrDefault()?.Data;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ids.getAccountInfo: Response Error Message:");
                    Console.WriteLine(response.GetErrorMessage());
                    Console.WriteLine($"ids.getAccountInfo: Response Error:{response.GetLog()}");
                }
            }
        }
        catch (Exception ex)
        {
            var log = ex.ToString();
            Console.WriteLine(log);
            // throw;
        }

        Console.WriteLine();
    }

    public void SetAccountInfo(UserProfile usrProfile)
    {
        // accounts.setAccountInfo
        https://developers.gigya.com/display/GD/ids.setAccountInfo+REST
        GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaIdsSetAccountInfo, null, true, appSetting.GigyaSettings.GigyaUserKey);
        request.SetParam("UID", usrProfile.UID);
        request.SetParam("profile", JsonConvert.SerializeObject(usrProfile.Profile));

        try
        {
            GSResponse response = request.Send();

            if (response != null)
            {
                Console.WriteLine("accounts.setAccountInfo: Response Error Code:");
                Console.WriteLine(response.GetErrorCode());
                // Console.WriteLine("accounts.setAccountInfo: Response JSON String:");
                // Console.WriteLine(response.GetData().ToJsonString());
                Console.WriteLine("accounts.setAccountInfo: Response Text:");
                Console.WriteLine(response.GetResponseText());
                if (response.GetErrorCode() != Constants.GigyaStatusCodeSuccess)
                {
                    Console.WriteLine("accounts.setAccountInfo: Response Error Message:");
                    Console.WriteLine(response.GetErrorMessage());
                    Console.WriteLine($"accounts.setAccountInfo: Response Error:{response.GetLog()}");
                }
            }
        }
        catch (Exception ex)
        {
            var log = ex.ToString();
            Console.WriteLine(log);
            // throw;
        }

        Console.WriteLine();
    }
    
    public string Register(string emailAddress, string password)
    {
        // The regToken expires one hour after it is produced.
        string regToken = null;

        // accounts.register
        // https://developers.gigya.com/display/GD/accounts.register+REST
        GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaAccountsRegister, null, true, appSetting.GigyaSettings.GigyaUserKey);

        request.SetParam("email", emailAddress);
        request.SetParam("password", password);
        request.SetParam("finalizeRegistration", true);

        try
        {
            GSResponse response = request.Send();

            if (response != null)
            {
                Console.WriteLine("accounts.register:");
                Console.WriteLine("accounts.register: Response Error Code:");
                Console.WriteLine(response.GetErrorCode());
                // Console.WriteLine("accounts.register: Response Data JSON String:");
                // Console.WriteLine(response.GetData().ToJsonString());
                Console.WriteLine("accounts.register: Response Text:");
                Console.WriteLine(response.GetResponseText());

                if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
                {
                    // RegisterResponse register = JsonConvert.DeserializeObject<RegisterResponse>(response.GetData().ToJsonString());
                    RegisterResponse register = JsonConvert.DeserializeObject<RegisterResponse>(response.GetResponseText());
                    // ProspectUserRegistrationResult prospectUserRegisterResult = JsonConvert.DeserializeObject<ProspectUserRegistrationResult>(response.GetData().ToJsonString());
                    // ProspectUserRegistrationResult prospectUserRegisterResult = JsonConvert.DeserializeObject<ProspectUserRegistrationResult>(response.GetResponseText());

                    if (register != null)
                    {
                        if (register.RegToken != null)
                        {
                            regToken = register.RegToken;
                            Console.WriteLine($"The regToken expires one hour after it is produced:\n{regToken}\n");
                        }
                        else if (register.SessionInfo != null)
                        {
                            regToken = register.SessionInfo.CookieValue;
                            Console.WriteLine($"The regToken (in SessionInfo.CookieValue) expires one hour after it is produced:\n{regToken}\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("accounts.register: Response Error Message:");
                    Console.WriteLine(response.GetErrorMessage());
                    Console.WriteLine($"accounts.register: Response Error:{response.GetLog()}");
                }
            }
        }
        catch (Exception ex)
        {
            var log = ex.ToString();
            Console.WriteLine(log);
            // throw;
        }

        Console.WriteLine();

        return regToken;
    }

    public string Register(ProspectUserRegistration prospectUserRegistration)
    {
        // The regToken expires one hour after it is produced.
        string regToken = null;

        // accounts.register
        // https://developers.gigya.com/display/GD/accounts.register+REST
        GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaAccountsRegister, null, true, appSetting.GigyaSettings.GigyaUserKey);

        request.SetParam("data", JsonConvert.SerializeObject(prospectUserRegistration.Data));
        request.SetParam("profile", JsonConvert.SerializeObject(prospectUserRegistration.Profile));
        request.SetParam("email", prospectUserRegistration.Email);
        request.SetParam("password", prospectUserRegistration.Password);
        request.SetParam("finalizeRegistration", prospectUserRegistration.FinalizeRegistration.ToString());

        try
        {
            GSResponse response = request.Send();

            if (response != null)
            {
                Console.WriteLine("accounts.register:");
                Console.WriteLine("accounts.register: Response Error Code:");
                Console.WriteLine(response.GetErrorCode());
                // Console.WriteLine("accounts.register: Response Data JSON String:");
                // Console.WriteLine(response.GetData().ToJsonString());
                Console.WriteLine("accounts.register: Response Text:");
                Console.WriteLine(response.GetResponseText());

                if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
                {
                    // RegisterResponse register = JsonConvert.DeserializeObject<RegisterResponse>(response.GetData().ToJsonString());
                    RegisterResponse register = JsonConvert.DeserializeObject<RegisterResponse>(response.GetResponseText());
                    // ProspectUserRegistrationResult prospectUserRegisterResult = JsonConvert.DeserializeObject<ProspectUserRegistrationResult>(response.GetData().ToJsonString());
                    // ProspectUserRegistrationResult prospectUserRegisterResult = JsonConvert.DeserializeObject<ProspectUserRegistrationResult>(response.GetResponseText());

                    if (register != null)
                    {
                        if (register.RegToken != null)
                        {
                            regToken = register.RegToken;
                            Console.WriteLine($"The regToken expires one hour after it is produced:\n{regToken}\n");
                        }
                        else if (register.SessionInfo != null)
                        {
                            regToken = register.SessionInfo.CookieValue;
                            Console.WriteLine($"The regToken (in SessionInfo.CookieValue) expires one hour after it is produced:\n{regToken}\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("accounts.register: Response Error Message:");
                    Console.WriteLine(response.GetErrorMessage());
                    Console.WriteLine($"accounts.register: Response Error:{response.GetLog()}");
                }
            }
        }
        catch (Exception ex)
        {
            var log = ex.ToString();
            Console.WriteLine(log);
            // throw;
        }

        Console.WriteLine();

        return regToken;
    }

    public UserProfile GetAccountInfoByGigyaId(string uid)
    {
        // accounts.getAccountInfo
        // https://developers.gigya.com/display/GD/accounts.getAccountInfo+REST
        GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaAccountsGetAccountInfo, null, true, appSetting.GigyaSettings.GigyaUserKey);
        request.SetParam("UID", uid);

        UserProfile profile = null;

        try
        {
            GSResponse response = request.Send();

            if (response != null)
            {
                Console.WriteLine("accounts.getAccountInfo: Response Error Code:");
                Console.WriteLine(response.GetErrorCode());
                // Console.WriteLine("accounts.getAccountInfo: Response JSON String:");
                // Console.WriteLine(response.GetData().ToJsonString());
                Console.WriteLine("accounts.getAccountInfo: Response Text:");
                Console.WriteLine(response.GetResponseText());
                if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
                {
                    // Refer to Fix 2 for .NET Core
                    // profile = JsonConvert.DeserializeObject<UserProfile>(response.GetData().ToJsonString());
                    profile = JsonConvert.DeserializeObject<UserProfile>(response.GetResponseText());
                }
                else
                {
                    Console.WriteLine("accounts.getAccountInfo: Response Error Message:");
                    Console.WriteLine(response.GetErrorMessage());
                    Console.WriteLine($"accounts.getAccountInfo: Response Error:{response.GetLog()}");
                }
            }
        }
        catch (Exception ex)
        {
            var log = ex.ToString();
            Console.WriteLine(log);
            // throw;
        }

        Console.WriteLine();

        return profile;
    }

    public UserProfile GetAccountInfoRegToken(string regToken)
    {
        // accounts.getAccountInfo
        // https://developers.gigya.com/display/GD/accounts.getAccountInfo+REST
        GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaAccountsGetAccountInfo, null, true, appSetting.GigyaSettings.GigyaUserKey);
        request.SetParam("regToken", regToken);

        UserProfile profile = null;

        try
        {
            GSResponse response = request.Send();

            if (response != null)
            {
                Console.WriteLine("accounts.getAccountInfo: Response Error Code:");
                Console.WriteLine(response.GetErrorCode());
                // Console.WriteLine("accounts.getAccountInfo: Response JSON String:");
                // Console.WriteLine(response.GetData().ToJsonString());
                Console.WriteLine("accounts.getAccountInfo: Response Text:");
                Console.WriteLine(response.GetResponseText());
                if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
                {
                    // Refer to Fix 2 for .NET Core
                    // profile = JsonConvert.DeserializeObject<UserProfile>(response.GetData().ToJsonString());
                    profile = JsonConvert.DeserializeObject<UserProfile>(response.GetResponseText());
                }
                else
                {
                    Console.WriteLine("accounts.getAccountInfo: Response Error Message:");
                    Console.WriteLine(response.GetErrorMessage());
                    Console.WriteLine($"accounts.getAccountInfo: Response Error:{response.GetLog()}");
                }
            }
        }
        catch (Exception ex)
        {
            var log = ex.ToString();
            Console.WriteLine(log);
            // throw;
        }

        Console.WriteLine();

        return profile;
    }

    public void ProspectUserResetPassword(string email)
    {
        // accounts.resetPassword
        // https://developers.gigya.com/display/GD/accounts.resetPassword+REST
        GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaAccountsResetPassword, null, true, appSetting.GigyaSettings.GigyaUserKey);
        request.SetParam("loginId", email);
        // request.SetParam("sendEmail", true);
        request.SetParam("sendEmail", false);

        try
        {
            GSResponse response = request.Send();

            if (response != null)
            {
                Console.WriteLine("accounts.resetPassword: Response Error Code:");
                Console.WriteLine(response.GetErrorCode());
                // Console.WriteLine("accounts.resetPassword: Response JSON String:");
                // Console.WriteLine(response.GetData().ToJsonString());
                Console.WriteLine("accounts.resetPassword: Response Text:");
                Console.WriteLine(response.GetResponseText());

                if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
                {
                    // GigyaResetPasswordResult resetPasswordResult = JsonConvert.DeserializeObject<GigyaResetPasswordResult>(response.GetData().ToJsonString());
                    GigyaResetPasswordResult resetPasswordResult = JsonConvert.DeserializeObject<GigyaResetPasswordResult>(response.GetResponseText());

                    if (resetPasswordResult != null && resetPasswordResult.PasswordResetToken != null)
                    {
                        Console.WriteLine($"PasswordResetToken: {resetPasswordResult.PasswordResetToken}");
                    }
                }
                else
                {
                    Console.WriteLine("accounts.resetPassword: Response Error Message:");
                    Console.WriteLine(response.GetErrorMessage());
                    Console.WriteLine($"accounts.resetPassword: Response Error:{response.GetLog()}");
                }
            }
        }
        catch (Exception ex)
        {
            var log = ex.ToString();
            Console.WriteLine(log);
            // throw;
        }

        Console.WriteLine();
    }

    public void DeleteProfile(string gigyaId)
    {
        // accounts.deleteAccount
        // https://developers.gigya.com/display/GD/accounts.deleteAccount+REST
        GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaAccountsDeleteAccount, null, true, appSetting.GigyaSettings.GigyaUserKey);
        request.SetParam("UID", gigyaId);

        try
        {
            GSResponse response = request.Send();

            if (response != null)
            {
                Console.WriteLine("accounts.deleteAccount: Response Error Code:");
                Console.WriteLine(response.GetErrorCode());
                // Console.WriteLine("accounts.deleteAccount: Response JSON String:");
                // Console.WriteLine(response.GetData().ToJsonString());
                Console.WriteLine("accounts.deleteAccount: Response Text:");
                Console.WriteLine(response.GetResponseText());

                if (response.GetErrorCode() != Constants.GigyaStatusCodeSuccess)
                {
                    Console.WriteLine("accounts.deleteAccount: Response Error Message:");
                    Console.WriteLine(response.GetErrorMessage());
                    Console.WriteLine($"accounts.deleteAccount: Response Error:{response.GetLog()}");
                }
            }
        }
        catch (Exception ex)
        {
            var log = ex.ToString();
            Console.WriteLine(log);
            // throw;
        }

        Console.WriteLine();
    }

    public GigyaOrganisationResult GetOrganisationDataStore(string oid)
    {
        // ds.search
        // https://developers.gigya.com/display/GD/ds.search+REST
        GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaDsSearch, null, true, appSetting.GigyaSettings.GigyaUserKey);
        request.SetParam("query", $"SELECT * FROM organization where oid='{oid}'");

        GigyaOrganisationResult organisationResult = new GigyaOrganisationResult();

        try
        {
            GSResponse response = request.Send();

            if (response != null)
            {
                Console.WriteLine("ds.search: Response Error Code:");
                Console.WriteLine(response.GetErrorCode());
                // Console.WriteLine("ds.search: Response JSON String:");
                // Console.WriteLine(response.GetData().ToJsonString());
                Console.WriteLine("ds.search: Response Text:");
                Console.WriteLine(response.GetResponseText());

                if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
                {
                    // Refer to Fix 2 for .NET Core
                    // organisationResult = JsonConvert.DeserializeObject<GigyaOrganisationResult>(response.GetData().ToJsonString());
                    organisationResult = JsonConvert.DeserializeObject<GigyaOrganisationResult>(response.GetResponseText());
                }
                else
                {
                    Console.WriteLine("ds.search: Response Error Message:");
                    Console.WriteLine(response.GetErrorMessage());
                    Console.WriteLine($"ds.search: Response Error:{response.GetLog()}");
                }
            }
        }
        catch (Exception ex)
        {
            var log = ex.ToString();
            Console.WriteLine(log);
            // throw;
        }

        Console.WriteLine();

        return organisationResult;
    }

    public RancherDetails GetRancherDetails(string email)
    {
        RancherDetails rancher = new RancherDetails();
        rancher.RanchName = "Feldranchman";
        rancher.FirstName = "Feldman";
        rancher.LastName = "John";
        rancher.Address1 = "900";
        rancher.Address2 = "South Beretania Street";
        rancher.City = "Honolulu";
        rancher.State = "Hawaii";
        rancher.ZipCode = "96814";
        rancher.Phone = "8085328700";
        rancher.Email = email;

        _ = ValidateAddress
        (
            new Address()
            {
                City = rancher.City,
                PostalCode = rancher.ZipCode,
                State = rancher.State,
                AddressLine1 = rancher.Address1 + (!string.IsNullOrWhiteSpace(rancher.Address2) ? ", " + rancher.Address2 : string.Empty),
            }
        );

        return rancher;
    }

    public ProspectUserRegistration GetProspectUser(RancherDetails rancher, string pwd, string oid)
    {
        ProspectUserRegistration customer = new ProspectUserRegistration()
        {
            Email = rancher.Email,
            Password = pwd,
            Profile = new GigyaUserProfile()
            {
                FirstName = rancher.FirstName,
                LastName = rancher.LastName,
                Address = rancher.Address1 + (!string.IsNullOrWhiteSpace(rancher.Address2) ? ", " + rancher.Address2 : string.Empty),
                City = rancher.City,
                Zip = rancher.ZipCode,
            },
            Data = new GigyaData()
            {
                QualificationType = Constants.QualificationTypeRan,
                BusinessType = Constants.BusinessTypeProducer,
                Prefix = rancher.Prefix,
                BusinessName = rancher.RanchName,
                RegionCode = rancher.State,
                ProvinceCode = rancher.State,
                ContactTypes = new ContactType() { ContactType1 = Constants.Phone, ContactType2 = Constants.Office, ContactType3 = Constants.Fax },
                ContactValues = new ContactValue() { ContactValue1 = rancher.Phone, ContactValue2 = string.Empty, ContactValue3 = string.Empty },
                MobilePhone = Constants.MobilePhone,
                Oid = oid,
            },
            FinalizeRegistration = true,
        };

        return customer;
    }

    public string GenerateRandomPassword()
    {
        int requiredLength = 10;
        int requiredUniqueChars = 4;
        bool requireDigit = true;
        bool requireLowercase = true;
        bool requireNonAlphanumeric = true;
        bool requireUppercase = true;

        string[] randomChars = new[]
        {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

        Random rand = new Random(Environment.TickCount);
        List<char> chars = new List<char>();

        if (requireUppercase)
        {
            chars.Insert(rand.Next(0, chars.Count), randomChars[0][rand.Next(0, randomChars[0].Length)]);
        }

        if (requireLowercase)
        {
            chars.Insert(rand.Next(0, chars.Count), randomChars[1][rand.Next(0, randomChars[1].Length)]);
        }

        if (requireDigit)
        {
            chars.Insert(rand.Next(0, chars.Count), randomChars[2][rand.Next(0, randomChars[2].Length)]);
        }

        if (requireNonAlphanumeric)
        {
            chars.Insert(rand.Next(0, chars.Count), randomChars[3][rand.Next(0, randomChars[3].Length)]);
        }

        for (int i = chars.Count; i < requiredLength || chars.Distinct().Count() < requiredUniqueChars; i++)
        {
            string rcs = randomChars[rand.Next(0, randomChars.Length)];
            chars.Insert(rand.Next(0, chars.Count), rcs[rand.Next(0, rcs.Length)]);
        }

        return new string(chars.ToArray());
    }

    public bool ValidateAddress(Address addr)
    {
        IAddressValidaor smartyValidation = new AddressValidator();
        Tuple<bool, IDictionary<string, string>> validationResult = smartyValidation.ValidateAddress(addr);

        Console.WriteLine("SmartyStreets Address Validation");
        validationResult.Item2.ToList().ForEach(kvp => Console.WriteLine(kvp.Value));
        Console.WriteLine();

        return validationResult.Item1;
    }

    public T Get<T>(string key, string value, string method, bool useProspectApi = false) where T : new()
    {
        Dictionary<string, object> data = new Dictionary<string, object>()
        {
            { key, value }
        };

        GSResponse response = GigyaRequest(data, method);

        if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
        {
            return JsonConvert.DeserializeObject<T>(response.GetResponseText());
        }
        return new T();
    }

    private GSResponse GigyaRequest(Dictionary<string, object> dictionary, string method, bool useProspectApiKey = false)
    {
        string apiKey = useProspectApiKey ? appSetting.GigyaSettings.GigyaProspectApiKey : appSetting.GigyaSettings.GigyaApiKey;

        GSRequest request = new GSRequest(apiKey, appSetting.GigyaSettings.GigyaSecretKey, method, null, true, appSetting.GigyaSettings.GigyaUserKey);

        foreach (var keyValuePair in dictionary)
        {
            request.SetParam(keyValuePair.Key, keyValuePair.Value.ToString());
        }

        var response = request.Send();
        return response;
    }
}


