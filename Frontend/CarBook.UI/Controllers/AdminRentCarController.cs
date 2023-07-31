using CarBook.UI.Models.RentCar;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.UI.Controllers
{
    public class AdminRentCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminRentCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7244/api/RentCar");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRentCarViewModel>>(jsonData);
                return View(values);

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ApprovedRentCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7244/api/RentCar/RentCarApproved?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRentCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7244/api/RentCar/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateRentCarViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRentCar(UpdateRentCarViewModel updateRentCarViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateRentCarViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7244/api/RentCar", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> CancelRentCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7244/api/RentCar/RentCarCancel?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }
            return View();
        }

        public async Task<IActionResult> WaitRentCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7244/api/RentCar/RentCarWait?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
