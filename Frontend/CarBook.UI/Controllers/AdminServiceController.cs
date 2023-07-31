using CarBook.UI.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;


namespace CarBook.UI.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7244/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceViewModel>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public IActionResult AddService()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService(AddServiceViewModel addServiceViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(addServiceViewModel);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7244/api/Service", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            return View();

        }

        public async Task<ActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessege = await client.DeleteAsync($"https://localhost:7244/api/Service?id={id}");
            if (responseMessege.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7244/api/Service/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceViewModel updateServiceViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateServiceViewModel);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await client.PutAsync("https://localhost:7244/api/Service", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }

            return View();
        }
    }
}
