using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace User_Login_MVC.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(User user)
        {
            UsersEntities usersEntities = new UsersEntities();
            int? userId = usersEntities.ValidateUser(user.Username, user.Password).FirstOrDefault();

            string message = string.Empty;
            switch (userId.Value)
            {
                case -1:
                    message = "Username and/or password is incorrect.";
                    break;
                case -2:
                    message = "Account has not been activated.";
                    break;
                default:
                    FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                    return RedirectToAction("Profile");
            }

            ViewBag.Message = message;
            return View(user);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}