using Gigya.Socialize.SDK;
using GigyaApiClient.Abstract;
using GigyaApiClient.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigyaApiClient.Concrete
{
    public class GigyaService : IGigyaService
    {

        public APIResult GigyaTocken(string userId, string secret, string apiKey)
        {
            // Call the API
            var request = new GSAuthRequest(userId, secret, apiKey, "");

            return new APIResult() {

            };
        }

        public string ProspectUser()
        {
            throw new NotImplementedException();
        }
    }
}
