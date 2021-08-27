using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCProductsRegisterApp.Helper;
using MVCProductsRegisterApp.Models;
using System.Diagnostics;

namespace MVCProductsRegisterApp.Controllers
{
    public class HomeController : Controller
    {
        ProductAPI _api = new ProductAPI();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
