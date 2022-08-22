using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCore.Controllers
{
    // [Authorize]
    // [Authorize(Policy = "RequireAdminRole")] // Only for // "admin@example.com"
    // [Authorize(Policy = "RequireUserName")]
    [Authorize(Policy = "RequireUserNames")]
    // [Authorize(Roles = "Admin")] // Only for // "admin@example.com"
    public class SecretController : Controller
    {
        /*
        // GET: Secret
        public ActionResult Index()
        {
            return View();
        }
        */

        public ContentResult Secret()
        {
            // string html = "<a onclick='javascript: window.history.back();' style=\"color: #0000FF; text-decoration: underline; font-size: 15px; font-family: Arial; cursor: pointer;\">This is a secret!</a>";
            string html = "<a href='/Home/Index' style=\"color: #0000FF; text-decoration: underline; font-size: 15px; font-family: Arial; cursor: pointer;\">This is secret - Go Home</a>";

            HtmlString htmlString = new HtmlString(html);

            return Content(htmlString.ToString(), "text/html");
            // return new ContentResult { ContentType = "text/html", Content = html };
        }

        [AllowAnonymous]
        public ContentResult Overt()
        {
            HtmlString htmlString = null;
            string html = null;

            if (this.User.Identity.IsAuthenticated)
            {
                html = "<a href='/Secret/Secret' style =\"color: #0000FF; text-decoration: underline; font-size: 15px; font-family: Arial; cursor: pointer;\">Go to secret</a>";
                htmlString = new HtmlString(html);
            }
            else
            {
                html = "<a href='/Identity/Account/Login' style =\"color: #0000FF; text-decoration: underline; font-size: 15px; font-family: Arial; cursor: pointer;\">Login for secret</a>";
                htmlString = new HtmlString(html);
            }

            return Content(htmlString.ToString(), "text/html");
            // return new ContentResult { ContentType = "text/html", Content = html };
        }
    }
}