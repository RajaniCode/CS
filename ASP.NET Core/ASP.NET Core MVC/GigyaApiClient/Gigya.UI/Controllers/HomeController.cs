using Microsoft.AspNetCore.Mvc;

namespace Gigya.UI.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;

        /*
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */

        public IActionResult Index()
        {
            // return View();
            return RedirectToAction("Index", "Login", new { Area = "Account" });
        }

        /*
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        */
    }
}
