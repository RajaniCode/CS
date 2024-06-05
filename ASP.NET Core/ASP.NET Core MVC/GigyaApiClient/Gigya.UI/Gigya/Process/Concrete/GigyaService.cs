﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;
using Gigya.Socialize.SDK;
using Helpers.Gigya.Socialize.SDK;
using Gigya.Process.Model;
using Gigya.Process.Abstract;
using Gigya.Common;


namespace Gigya.Process.Concrete
{
    public class GigyaService : IGigyaService
    {
        private readonly AppSettings appSetting;

        public GigyaService()
        {
            appSetting = new AppSettings();
        }

        public UserSignatureValidationResult ValidateUserSignature(LoggedUser loggedUser)
        {
            // [header (1)].[payload (2)].[signature (3)]
            var segments = loggedUser.IdToken.Split('.');

            if (segments.Length != 3)
            {
                return null;
            }

            var jwtHeader = SigUtil.SafeNoException(() => SigUtil.Deserialize<JwtHeader>(segments[0]));

            string kid = jwtHeader?.Kid;

            if (kid == null)
            {
                return null;
            }

            // Get Public Key
            var method = appSetting.GigyaSettings.GigyaAccountsGetJwtPublicKey;

            var publicJWK = Get<GigyaPublicKey>("UID", loggedUser.UID, method);

            if (publicJWK == null)
            {
                return null;
            }

            // Validate JWT Token using Public Key
            using (var rsa = RSAFromKeyParams(publicJWK))
            {
                if (rsa == null)
                {
                    return null; // Failed to instantiate Public Key instance from JWK
                }

                var data = Encoding.UTF8.GetBytes(segments[0] + '.' + segments[1]);
                var signature = segments[2].FromBase64UrlString();

                var valid = rsa.VerifyData(data, "SHA256", signature);

                if (!valid)
                {
                    return null; // Failed to validate the JWT Signature
                }
            }

            var claims = SigUtil.Deserialize<Dictionary<string, object>>(segments[1]);

            // Validate if the JWT Token created in last 2 minutes = 2 * 60
            if (!SigUtil.IsTimestampValid((long)claims["iat"], Constants.JWTTokenValidationMinutes))
            {
                return null; // Failed to validate the JWT Token issued at
            }

            return new UserSignatureValidationResult()
            {
                UID = claims["sub"].ToString(),
                IsLoggedIn = (bool)claims["isLoggedIn"],
            };
        }

        public T Get<T>(string key, string value, string method, bool useProspectApi = false) where T : new()
        {
            IDictionary<string, string> data = new Dictionary<string, string>()
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

        private GSResponse GigyaRequest(IDictionary<string, string> dictionary, string method, bool useProspectApiKey = false)
        {
            string apiKey = useProspectApiKey ? appSetting.GigyaSettings.GigyaProspectApiKey : appSetting.GigyaSettings.GigyaApiKey;

            GSRequest request = new GSRequest(apiKey, appSetting.GigyaSettings.GigyaSecretKey, method, null, true, appSetting.GigyaSettings.GigyaUserKey);

            foreach (var keyValuePair in dictionary)
            {
                if (!string.IsNullOrWhiteSpace(keyValuePair.Key) && !string.IsNullOrWhiteSpace(keyValuePair.Value))
                {
                    request.SetParam(keyValuePair.Key, keyValuePair.Value);
                }
            }

            var response = request.Send();
            return response;
        }

        private RSACryptoServiceProvider RSAFromKeyParams(GigyaPublicKey jwk)
        {
            RSACryptoServiceProvider rsa;
            try
            {
                var n = jwk.N.FromBase64UrlString();
                var e = jwk.E.FromBase64UrlString();
                rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(new RSAParameters
                {
                    Modulus = n,
                    Exponent = e
                });
            }
            catch (CryptographicException ex)
            {
                var log = ex.ToString();
                throw;
            }
            catch (Exception ex)
            {
                var log = ex.ToString();
                throw;
            }

            return rsa;
        }

        public UserProfile GetUserProfileByGigyaId(string gigyaId)
        {
            // ids.getAccountInfo
            // https://developers.gigya.com/display/GD/ids.getAccountInfo+REST
            GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaIdsGetAccountInfo, null, true, appSetting.GigyaSettings.GigyaUserKey);
            request.SetParam("UID", gigyaId);

            UserProfile usrProfile = null;

            try
            {
                GSResponse response = request.Send();

                if (response != null)
                {
                    if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
                    {
                        // Refer to Fix 2 for .NET Core
                        // usrProfile = JsonConvert.DeserializeObject<UserProfile>(response.GetData().ToJsonString());
                        usrProfile = JsonConvert.DeserializeObject<UserProfile>(response.GetResponseText());
                        return usrProfile;
                    }
                }
            }
            catch (Exception ex)
            {
                var log = ex.ToString();
                // throw;
            }

            return usrProfile;
        }

        public GigyaResponse DeleteProfile(string gigyaId)
        {
            // accounts.deleteAccount
            // https://developers.gigya.com/display/GD/accounts.deleteAccount+REST
            GSRequest request = new GSRequest(appSetting.GigyaSettings.GigyaApiKey, appSetting.GigyaSettings.GigyaSecretKey, appSetting.GigyaSettings.GigyaAccountsDeleteAccount, null, true, appSetting.GigyaSettings.GigyaUserKey);
            request.SetParam("UID", gigyaId);

            GigyaResponse gigResponse = null;

            try
            {
                GSResponse response = request.Send();

                if (response != null)
                {
                    if (response.GetErrorCode() == Constants.GigyaStatusCodeSuccess)
                    {
                        // Refer to Fix 2 for .NET Core
                        // gigResponse = JsonConvert.DeserializeObject<GigyaResponse>(response.GetData().ToJsonString());
                        gigResponse = JsonConvert.DeserializeObject<GigyaResponse>(response.GetResponseText());
                        return gigResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                var log = ex.ToString();
                // throw;
            }

            return gigResponse;
        }
    }
}
