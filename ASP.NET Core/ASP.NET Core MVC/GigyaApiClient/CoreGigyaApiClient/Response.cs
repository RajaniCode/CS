using System;
using System.Collections.Generic;
// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;

/// <summary>
/// Class reperesenting response with UID for Register on Gigya
/// https://developers.gigya.com/display/GD/accounts.register+REST
/// If not passing the include parameter, only the user's profile object is returned by default
/// </summary>
public class RegisterResponse
{
    [JsonProperty("apiVersion")]
    public int ApiVersion { get; set; }

    [JsonProperty("callId")]
    public string CallId { get; set; }

    [JsonProperty("errorCode")]
    public int ErrorCode { get; set; }

    [JsonProperty("errorDetails")]
    public string ErrorDetails { get; set; }

    [JsonProperty("errorMessage")]
    public string ErrorMessage { get; set; }

    [JsonProperty("fullEventName")]
    public string FullEventName { get; set; }

    [JsonProperty("time")]
    public string Time { get; set; }

    [ObsoleteAttribute("This property is deprecated and only returned for backward compatibility.", true)]
    [JsonProperty("statusCode")]
    public int StatusCode { get; set; }

    [ObsoleteAttribute("This property is deprecated and only returned for backward compatibility.", true)]
    [JsonProperty("statusReason")]
    public string StatusReason { get; set; }

    [JsonProperty("sessionInfo")]
    public SessionInfo SessionInfo { get; set; }

    [JsonProperty("regToken")]
    public string RegToken { get; set; }

    [JsonProperty("unverifiedEmails")]
    public List<string> UnverifiedEmails { get; set; }

    [JsonProperty("validationErrors")]
    public List<ValidationError> ValidationErrors { get; set; }

    [JsonProperty("newUser")]
    public bool NewUser { get; set; }

    [JsonProperty("UID")]
    public string UID { get; set; }

    [JsonProperty("created")]
    public string Created { get; set; }

    [JsonProperty("createdTimestamp")]
    public long CreatedTimestamp { get; set; }

    [JsonProperty("data")]
    public Data Data { get; set; }

    [JsonProperty("emails")]
    public Emails Emails { get; set; }

    // [JsonProperty("groups")]
    // public Groups Groups { get; set; }

    [JsonProperty("identities")]
    public List<Identity> Identities { get; set; }

    [ObsoleteAttribute("This property is deprecated and will always return 0.", true)]
    [JsonProperty("iRank")]
    public float IRank { get; set; }

    [JsonProperty("isActive")]
    public bool IsActive { get; set; }

    [ObsoleteAttribute("This property is deprecated' please use lockedUntil via accounts.search instead.", true)]
    [JsonProperty("isLockedOut")]
    public bool IsLockedOut { get; set; }

    [JsonProperty("isRegistered")]
    public bool IsRegistered { get; set; }

    [JsonProperty("isVerified")]
    public bool IsVerified { get; set; }

    [JsonProperty("lastLogin")]
    public string LastLogin { get; set; }

    [JsonProperty("lastLoginLocation")]
    public LastLoginLocation LastLoginLocation { get; set; }

    [JsonProperty("lastLoginTimestamp")]
    public long LastLoginTimestamp { get; set; }

    [JsonProperty("lastUpdated")]
    public string LastUpdated { get; set; }

    [JsonProperty("lastUpdatedTimestamp")]
    public long LastUpdatedTimestamp { get; set; }

    [JsonProperty("loginIDs")]
    public List<LoginID> LoginIDs { get; set; }

    [JsonProperty("loginProvider")]
    public string LoginProvider { get; set; }

    [JsonProperty("oldestDataUpdated")]
    public string OldestDataUpdated { get; set; }

    [JsonProperty("oldestDataUpdatedTimestamp")]
    public long OldestDataUpdatedTimestamp { get; set; }

    [JsonProperty("password")]
    public Password Password { get; set; }

    [ObsoleteAttribute("This property is deprecated in server to server REST calls.", true)]
    [JsonProperty("UIDSignature")]
    public string UIDSignature { get; set; }

    [ObsoleteAttribute("This property is deprecated in server to server REST calls.", true)]
    [JsonProperty("signatureTimestamp")]
    public string SignatureTimestamp { get; set; }

    [JsonProperty("phoneNumber")]
    public string PhoneNumber { get; set; }

    // [JsonProperty("preferences")]
    // public Preferences Preferences { get; set; }

    [JsonProperty("profile")]
    public Profile Profile { get; set; }

    [JsonProperty("rbaPolicy")]
    public RbaPolicy RbaPolicy { get; set; }

    [JsonProperty("registered")]
    public string Registered { get; set; }

    [JsonProperty("registeredTimestamp")]
    public string RegisteredTimestamp { get; set; }

    [JsonProperty("regSource")]
    public string RegSource { get; set; }

    [JsonProperty("socialProviders")]
    public string SocialProviders { get; set; }

    // [JsonProperty("subscriptions")]
    // public Subscriptions Subscriptions { get; set; }

    // [ObsoleteAttribute("This property is deprecated and should not be relied upon.", true)]
    // [JsonProperty("userInfo")]
    // public UserInfo  UserInfo { get; set; }

    [JsonProperty("verified")]
    public string Verified { get; set; }

    [JsonProperty("verifiedTimestamp")]
    public long VerifiedTimestamp { get; set; }
}

public class SessionInfo
{
    [JsonProperty("cookieName")]
    public string CookieName { get; set; }

    [JsonProperty("cookieValue")]
    public string CookieValue { get; set; }
}

public class ValidationError
{
    [JsonProperty("errorCode")]
    public string ErrorCode { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("fieldName")]
    public string FieldName { get; set; }
}
public class LoginID
{
    [JsonProperty("emails")]
    public List<Emails> Emails { get; set; }

    [JsonProperty("unverifiedEmails")]
    public List<string> UnverifiedEmails { get; set; }
}

public class Emails
{
    [JsonProperty("verified")]
    public List<string> Verified { get; set; }

    [JsonProperty("unverified")]
    public List<string> Unverified { get; set; }
}

public class Identity
{
    [JsonProperty("provider")]
    public string Provider { get; set; }

    [JsonProperty("providerUID")]
    public string ProviderUID { get; set; }

    [JsonProperty("isLoginIdentity")]
    public bool IsLoginIdentity { get; set; }

    [JsonProperty("photoURL")]
    public string PhotoURL { get; set; }

    [JsonProperty("thumbnailURL")]
    public string ThumbnailURL { get; set; }

    [JsonProperty("firstName")]
    public string FirstName { get; set; }

    [JsonProperty("lastName")]
    public string LastName { get; set; }

    [JsonProperty("gender")]
    public string Gender { get; set; }

    [JsonProperty("age")]
    public string Age { get; set; }

    [JsonProperty("birthDay")]
    public int BirthDay { get; set; }

    [JsonProperty("birthMonth")]
    public int BirthMonth { get; set; }

    [JsonProperty("birthYear")]
    public int BirthYear { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("profileURL")]
    public string ProfileURL { get; set; }

    [JsonProperty("proxiedEmail")]
    public string ProxiedEmail { get; set; }

    [JsonProperty("allowsLogin")]
    public bool AllowsLogin { get; set; }

    [JsonProperty("isExpiredSession")]
    public bool IsExpiredSession { get; set; }

    [JsonProperty("lastUpdated")]
    public string LastUpdated { get; set; }

    [JsonProperty("lastUpdatedTimestamp")]
    public long LastUpdatedTimestamp { get; set; }

    [JsonProperty("oldestDataUpdated")]
    public string OldestDataUpdated { get; set; }

    [JsonProperty("oldestDataUpdatedTimestamp")]
    public long OldestDataUpdatedTimestamp { get; set; }
}
public class Data
{
    [JsonProperty("hair")]
    public string Hair { get; set; }

    [JsonProperty("qualificationType")]
    public string QualificationType { get; set; }

    [JsonProperty("cultureCode")]
    public string CultureCode { get; set; }

    [JsonProperty("regionCode")]
    public string RegionCode { get; set; }

    [JsonProperty("province")]
    public string Province { get; set; }

    [JsonProperty("prefix")]
    public string Prefix { get; set; }

    [JsonProperty("countryCode")]
    public string CountryCode { get; set; }

    [JsonProperty("function")]
    public string Function { get; set; }

    [JsonProperty("businessName")]
    public string BusinessName { get; set; }

    [JsonProperty("contactTypes.contactType1")]
    public string ContactType1 { get; set; }

    [JsonProperty("contactTypes.contactType2")]
    public string ContactType2 { get; set; }

    [JsonProperty("contactTypes.contactType3")]
    public string ContactType3 { get; set; }

    [JsonProperty("contactValues.contactValue1")]
    public string ContactValue1 { get; set; }

    [JsonProperty("contactValues.contactValue2")]
    public string ContactValue2 { get; set; }

    [JsonProperty("contactValues.contactValue3")]
    public string ContactValue3 { get; set; }

    [JsonProperty("businessType")]
    public string BusinessType { get; set; }
}
public class Password
{
    [JsonProperty("hash")]
    public string Hash { get; set; }

    [JsonProperty("hashSettings")]
    public HashSettings HashSettings { get; set; }
}

public class LastLoginLocation
{
    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("coordinates")]
    public Coordinates Coordinates { get; set; }
}

public class Coordinates
{
    [JsonProperty("lat")]
    public double Latitude { get; set; }

    [JsonProperty("lon")]
    public double Longitude { get; set; }
}

public class RbaPolicy
{
    [JsonProperty("riskPolicy")]
    public double RiskPolicy { get; set; }

    [JsonProperty("riskPolicyLocked")]
    public bool RiskPolicyLocked { get; set; }
}
public class HashSettings
{
    [JsonProperty("algorithm")]
    public string Algorithm { get; set; }

    [JsonProperty("rounds")]
    public long Rounds { get; set; }

    [JsonProperty("salt")]
    public string Salt { get; set; }
}

public class Profile
{
    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("firstName")]
    public string FirstName { get; set; }

    [JsonProperty("lastName")]
    public string LastName { get; set; }

    [JsonProperty("age")]
    public string Age { get; set; }

    [JsonProperty("gender")]
    public string Gender { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("photoURL")]
    public string PhotoURL { get; set; }

    [JsonProperty("thumbnailURL")]
    public string ThumbnailURL { get; set; }

    [JsonProperty("birthYear")]
    public int BirthYear { get; set; }

    [JsonProperty("birthMonth")]
    public int BirthMonth { get; set; }

    [JsonProperty("birthDay")]
    public int BirthDay { get; set; }

    [JsonProperty("profileURL")]
    public string ProfileURL { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("samlData")]
    public SamlData SamlData { get; set; }
}

public class SamlData
{
    // [JsonProperty("property")]
    // public string Property { get; set; }
}

