using CarBook.UI.Models.Car;
using CarBook.UI.Models.Contact;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.UI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7244/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactViewModel>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}
