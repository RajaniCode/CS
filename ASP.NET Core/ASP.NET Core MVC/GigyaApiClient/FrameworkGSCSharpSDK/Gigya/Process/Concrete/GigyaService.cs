using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
// Install-Package Newtonsoft.Json -Version 12.0.3
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

            // Validate if the JWT Token created in last 2 minutes = 60 * 2 // 60 minutes = 60 * 60
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
            try
            {
                var n = jwk.N.FromBase64UrlString();
                var e = jwk.E.FromBase64UrlString();
                var rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(new RSAParameters
                {
                    Modulus = n,
                    Exponent = e
                });
                return rsa;
            }
            catch (Exception ex)
            {
                var log = ex.ToString();
                // throw;
            }

            return null;
        }
    }
}
