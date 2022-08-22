using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Gigya.Process.Model;
using Gigya.UI.Areas.Account.ViewModels;
using Gigya.UI.Security;

namespace Gigya.UI.Areas.Account.Controllers
{
    // [Authorize(Roles = "SelectVACAdmin")]
    [Area("Account")]
    public class LoginStatusController : Controller
    {
        // public IActionResult LoggedIn(bool isLoggedIn, string gigyaId)
        public IActionResult LoggedIn(bool isLoggedIn)
        {
            var viewModel = new LoginStatus()
            {
                IsLoggedIn = isLoggedIn,
                GigyaId = User.GetUserGigyaId(),
            };

            ViewData["Status"] = isLoggedIn;

            return View("LoggedIn", viewModel);
        }

        // public async Task<IActionResult> LoggedOut([FromQuery] string gigyaId)
        public async Task<IActionResult> LoggedOut()
        {
            string gigyaId = User.GetUserGigyaId();
            GigyaAuthentication gigAuthentication = new GigyaAuthentication();
            LogoutResponse logoutResponse = gigAuthentication.Logout(gigyaId);

            var viewModel = new LoginStatus()
            {
                LogoutActiveSession = logoutResponse.LogoutActiveSession,
                GigyaId = gigyaId
            };

            ViewData["LogoutActiveSession"] = logoutResponse.LogoutActiveSession;

            _ =  $"User {User.Identity.Name} logged out at {DateTime.UtcNow}.";

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View("LoggedOut", viewModel);            
        }
    }
}
