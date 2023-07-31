using CarBook.UI.Models.Car;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.UI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7244/api/Car");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarViewModel>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public IActionResult AddCar()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(AddCarViewModel addCarViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(addCarViewModel);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7244/api/Car", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            return View();

        }

        public async Task<IActionResult> DeleteCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessege = await client.DeleteAsync($"https://localhost:7244/api/Car?id={id}");
            if (responseMessege.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7244/api/Car/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarViewModel updateCarViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateCarViewModel);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await client.PutAsync("https://localhost:7244/api/Car", stringContent);

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
