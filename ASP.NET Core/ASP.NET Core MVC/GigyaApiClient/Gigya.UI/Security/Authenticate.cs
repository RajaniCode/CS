using System;
using System.Collections.Generic;
using System.Security.Claims;
// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;
using Gigya.Model.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Gigya.UI.Security
{
    public class Authenticate
    {
        public static ClaimsIdentity AddAuthenticationTicketAsync(User user)
        {
            // user.RoleUser = null;
            var data = JsonConvert.SerializeObject(user, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, !string.IsNullOrWhiteSpace(user.FirstName) ? user.FullName : user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Sid, !string.IsNullOrWhiteSpace(user.UID) ? user.UID : string.Empty),
                new Claim(ClaimTypes.UserData, data != null ? data : string.Empty),
                new Claim(ClaimTypes.Role, user.Role != null && !string.IsNullOrWhiteSpace(user.Role.Name) ? user.Role.Name : string.Empty),
                new Claim(CustomClaimTypes.RoleId, user.Role != null && user.Role?.Id != null ? user.Role.Id.ToString() : string.Empty,  ClaimValueTypes.Integer32),
                new Claim(CustomClaimTypes.LastLogin, user.LastLoggedIn.HasValue ? user.LastLoggedIn.Value.ToString() : DateTime.Now.ToString(), ClaimValueTypes.DateTime)
            };

            ClaimsIdentity Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            return Identity;
        }
    }
}
