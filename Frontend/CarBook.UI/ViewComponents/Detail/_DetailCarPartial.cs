using CarBook.UI.Models.Car;
using CarBook.UI.Models.Detail;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.UI.ViewComponents.Detail
{
    public class _DetailCarPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DetailCarPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
