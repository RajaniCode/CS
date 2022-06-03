using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    [Authorize(Users = "email@example.com, e.mail@example.com, mail@example.com, admin@example.com, facebook@example.com")]
    // [Authorize(Roles = "Admin")] // Only for // [Authorize(Users = "admin@example.com")]

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
            // IHtmlString htmlString = new HtmlString("<a onclick='javascript: window.history.back();' style=\"color: #0000FF; text-decoration: underline; font-size: 15px; font-family: Arial; cursor: pointer;\">This is a secret!</a>");
            IHtmlString htmlString = new HtmlString("<a href='/Home/Index' style=\"color: #0000FF; text-decoration: underline; font-size: 15px; font-family: Arial; cursor: pointer;\">This is secret - Go Home</a>");
            return Content(htmlString.ToString());
        }

        [AllowAnonymous]
        public ContentResult Overt()
        {
            IHtmlString htmlString = null;
            if (this.User.Identity.IsAuthenticated)
            {
                htmlString = new HtmlString("<a href='/Secret/Secret' style =\"color: #0000FF; text-decoration: underline; font-size: 15px; font-family: Arial; cursor: pointer;\">Go to secret</a>");
            }
            else
            {
                htmlString = new HtmlString("<a href='/Account/Login' style =\"color: #0000FF; text-decoration: underline; font-size: 15px; font-family: Arial; cursor: pointer;\">Login for secret</a>");

            }
            return Content(htmlString.ToString());
        }
    }
}