using CarBook.UI.Models.Car;
using CarBook.UI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.UI.ViewComponents.Default
{
    public class _TestimonialPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
