using CarBook.UI.Models.Car;
using CarBook.UI.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.UI.ViewComponents.Car
{
    public class _CarPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
