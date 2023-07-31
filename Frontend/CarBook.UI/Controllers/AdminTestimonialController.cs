using CarBook.UI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.UI.Controllers
{
    public class AdminTestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminTestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7244/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialViewModel>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(AddTestimonialViewModel addTestimonialViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(addTestimonialViewModel);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7244/api/Testimonial", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            return View();

        }

        public async Task<ActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessege = await client.DeleteAsync($"https://localhost:7244/api/Testimonial?id={id}");
            if (responseMessege.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7244/api/Testimonial/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTestimonialViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialViewModel updateTestimonialViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateTestimonialViewModel);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await client.PutAsync("https://localhost:7244/api/Testimonial", stringContent);

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
