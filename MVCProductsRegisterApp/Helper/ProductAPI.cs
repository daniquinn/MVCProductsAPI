using System.Net.Http;

namespace MVCProductsRegisterApp.Helper
{
    public class ProductAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:44396/");
            return client;
        }
    }
}