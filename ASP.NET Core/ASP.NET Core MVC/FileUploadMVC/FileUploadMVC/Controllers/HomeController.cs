using System;
using System.Diagnostics;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using FileUploadMVC.Models;
using FileUploadMVC.Utilities;

namespace FileUploadMVC.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        private readonly IFileProvider _fileProvider;

        // public HomeController(ILogger<HomeController> logger, IFileProvider fileProvider)
        public HomeController(IOptions<AppSettings> config, IFileProvider fileProvider)
        {
            // _ = config ?? throw new ArgumentNullException(nameof(config));
            // _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
        }

        public IActionResult Index(HomeModel home)
        {
            // IDirectoryContents
            home.Files = _fileProvider.GetDirectoryContents(string.Empty);

            if (!string.IsNullOrEmpty(home.FileName))
            {
                var downloadFile = _fileProvider.GetFileInfo(home.FileName);
                return PhysicalFile(downloadFile.PhysicalPath, MediaTypeNames.Application.Octet, home.FileName);
            }

            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
