using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;
using Gigya.Common;
using Gigya.Model.Models;
using Gigya.Process.Abstract;
using Gigya.Process.Concrete;
using Gigya.Process.Model;
using Gigya.UI.Areas.Account.ViewModels;
using Gigya.UI.Security;


namespace Gigya.UI.Areas.Account.Controllers
{
    // [Authorize]
    [Area("Account")]
    public class LoginController : Controller
    {
        // [AllowAnonymous]
        public IActionResult Index(string viewName, bool redirectProfile = false, string Deleted = "false", string displayNotification = default, string prospectCode = default, int? eId = null, int? barnCardId = null)
        {
            // var framework = $"{Request.Url.Scheme}://{Request.Url.Host}{Request.Url.PathAndQuery}";
            // var core = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            /*
            var extensionMethod = Url.GetLocalUrl("/Account/LoginStatus/LoggedIn");
            LocalRedirectResult redirectResult = LocalRedirect(extensionMethod);
            */

            TempData["Error"] = TempData["Error"];

            if (string.IsNullOrWhiteSpace(viewName))
            {
                viewName = "gigya-login-screen"; // default value will be login
            }

            var viewModel = new Login()
            {
                RedirectProfile = redirectProfile,
                DisplayNotification = displayNotification,
                ProspectCode = prospectCode,
                ViewName = viewName,
            };

            return View("Index", viewModel);
        }

        // [HttpPost]
        // [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string gigyaId, string idToken)
        {
            GigyaAuthentication gigAuthentication = new GigyaAuthentication();

            if (!string.IsNullOrWhiteSpace(gigyaId) && !string.IsNullOrWhiteSpace(idToken))
            {
                UserSignatureValidationResult userSignatureValidation = gigAuthentication.Login(gigyaId, idToken);                            

                if (userSignatureValidation != null)
                {
                    if (userSignatureValidation.StatusCode == Constants.GigyaStatusCodeSuccess)
                    {
                        _ = userSignatureValidation.IsLoggedIn;
                        IGigyaService gigService = new GigyaService();
                        UserProfile usrProfile = gigService.GetUserProfileByGigyaId(gigyaId);

                        if (usrProfile != null)
                        {
                            User currentUser = new User();

                            /*
                            if (gigyaId == "149979")
                            {
                            string mockCurrentUder = string.Empty;
                                // 149979 // test_employee_1@mailinator.com // organisation_id // 168
                                mockDatabaseCurrentUder = "{\"ProspectCode\":null,\"Organisation\":{\"Id\":168,\"Name\":\"Dexxxxxxxl\",\"NarcId\":\"308815\",\"UmmOrganisationId\":30446,\"PremisesId\":null,\"AddressLine1\":\"27xxxxxxx.\",\"AddressLine2\":null,\"City\":\"Dexxxxxxxe\",\"RegionCode\":\"US-NJ\",\"CountryCode\":null,\"PostalCode\":\"07xxxxxxx4\",\"BusinessPhoneNumber\":null,\"FullAddress\":\"27xxxxxxx., Dexxxxxxxe, NJ, 07xxxxxxx4\"},\"Role\":{\"Id\":11,\"Name\":\"SelectVACAdmin\",\"MarketoRoleName\":\"Admin Asst/Recep.\",\"Permissions\":[{\"Id\":1},{\"Id\":2},{\"Id\":5},{\"Id\":8},{\"Id\":11},{\"Id\":14},{\"Id\":15},{\"Id\":17},{\"Id\":19},{\"Id\":7},{\"Id\":4},{\"Id\":20},{\"Id\":21},{\"Id\":22}],\"ResourceName\":\"\"},\"UID\":\"149979\",\"Enabled\":true,\"Deleted\":false,\"LastLoggedIn\":\"2020-12-18T18:30:03.333\",\"PasswordReset\":false,\"IsNew\":true,\"HasRoleJustChanged\":false,\"FullName\":\"Test Employee 1\",\"HasEnrolments\":true,\"Id\":25,\"FirstName\":\"Software\",\"LastName\":\"Developer\",\"Prefix\":null,\"Suffix\":null,\"Email\":\"test_employee_1@mailinator.com\",\"Telephone\":null}";
                                currentUser = JsonConvert.DeserializeObject<User>(mockDatabaseCurrentUder);
                            }
                            */

                            currentUser.UID = usrProfile.UID;
                            currentUser.Email = usrProfile.Profile.Email;
                            currentUser.FirstName = usrProfile.Profile.FirstName;
                            currentUser.LastName = usrProfile.Profile.LastName;

                            if (currentUser != null)
                            {
                                ClaimsIdentity userIdentity = Authenticate.AddAuthenticationTicketAsync(currentUser);
                                // await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(userIdentity));
                                // var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                                var authProperties = new AuthenticationProperties
                                {
                                    //AllowRefresh = <bool>,
                                    // Refreshing the authentication session should be allowed.

                                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                                    // The time at which the authentication ticket expires. A 
                                    // value set here overrides the ExpireTimeSpan option of 
                                    // CookieAuthenticationOptions set with AddCookie.

                                    //IsPersistent = true,
                                    // Whether the authentication session is persisted across 
                                    // multiple requests. When used with cookies, controls
                                    // whether the cookie's lifetime is absolute (matching the
                                    // lifetime of the authentication ticket) or session-based.

                                    //IssuedUtc = <DateTimeOffset>,
                                    // The time at which the authentication ticket was issued.

                                    // RedirectUri = "https://localhost:44387/Account/LoginStatus/LoggedIn",
                                    // RedirectUri = "http://localhost:5550/Account/LoginStatus/LoggedIn",
                                    // The full path or absolute URI to be used as an http 
                                    // redirect response value.
                                };

                                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(userIdentity), authProperties);

                                /*
                                bool isAuthenticated = userIdentity.IsAuthenticated;

                                foreach (var claim in userIdentity.Claims)
                                {
                                   var v1 = $"Claim:{claim.Type} Value:{claim.Value}";
                                }
                                */

                                // return RedirectToAction("LoggedIn", "LoginStatus", new { Area = "Account", isLoggedIn = userSignatureValidation.IsLoggedIn, gigyaId = usrProfile.UID });
                                return RedirectToAction("LoggedIn", "LoginStatus", new { Area = "Account", isLoggedIn = userSignatureValidation.IsLoggedIn });
                            }
                        }
                    }
                }

                TempData["Error"] = Constants.ErrorMessage;
                return RedirectToAction("Index", new { Area = "Account", Controller = "Login" });
            }
            else
            {
                TempData["Error"] = Constants.ErrorMessage;
                return RedirectToAction("Index", new { Area = "Account", Controller = "Login" });
            }
        }

        /*
        public ActionResult CheckSessionStatus()
        {
            bool sessionActive;
            IGigyaService gigyaService = new GigyaInterface();
            UserProfile profile = gigyaService.GetUserProfile(User.LoggedInUser.GigyaId);

            if (profile != null && profile.IsActive)
            {
                sessionActive = true;
            }
            else
            {
                sessionActive = false;
            }

            return Json(new { sessionActive }, JsonRequestBehavior.AllowGet);
        }
        */
    }
}
