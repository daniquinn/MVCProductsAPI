using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCProductsRegisterApp.Helper;
using MVCProductsRegisterApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MVCProductsRegisterApp.Controllers
{
    public class HomeController : Controller
    {
        ProductAPI _api = new ProductAPI();

        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/products");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(results);
            }
            return View(products);
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

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
    }
}
