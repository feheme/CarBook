using CarBook.UI.Models.Detail;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.UI.Controllers
{
    public class AdminDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7244/api/Detail");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDetailViewModel>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public IActionResult AddDetail()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDetail(AddDetailViewModel addDetailViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(addDetailViewModel);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7244/api/Detail", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            return View();

        }

        public async Task<ActionResult> DeleteDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessege = await client.DeleteAsync($"https://localhost:7244/api/Detail?id={id}");
            if (responseMessege.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7244/api/Detail/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDetailViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDetail(UpdateDetailViewModel updateDetailViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateDetailViewModel);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await client.PutAsync("https://localhost:7244/api/Detail", stringContent);

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
