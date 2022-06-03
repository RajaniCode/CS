using GigyaApiClient.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigyaApiClient.Abstract
{
    public interface IGigyaService
    {
        //public APIResult GigyaTocken(string userId, string secret, string apiKey);
        public string ProspectUser();
    }
}
