using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCProductsRegisterApp.Helper;
using MVCProductsRegisterApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Json;

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

        public async Task<IActionResult> Details(int Id)
        {
            var product = new Product();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/products/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Product>(results);
            }
            return View(product);
        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult create(Product product)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PostAsJsonAsync<Product>("api/products", product);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var product = new Product();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/products/{Id}");

            return RedirectToAction("Index");
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
