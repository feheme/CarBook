using CarBook.DataAccessLayer.Concrete;
using CarBook.UI.Models.Detail;
using CarBook.UI.Models.RentCar;
using CarBook.UI.ValidationRules.RentCarRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using System.Text;

namespace CarBook.UI.Controllers
{
    [AllowAnonymous]
    public class RentCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var errorMessages = TempData["ErrorMessages"];

            if (errorMessages != null)
            {
                ViewBag.ErrorMessages = errorMessages;
            }




            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7244/api/Detail");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDetailViewModel>>(jsonData);
            var filteredValues = values.Where(x => x.Total > 0).ToList();

            List<SelectListItem> values2 = filteredValues.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Name


            }).ToList();
            ViewBag.v = values2;

            return View();

        }

        [HttpGet]
        public PartialViewResult RentCar()
        {


            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> RentCar(CreateRentCarViewModel createRentCarViewModel)
        {


            CreateRentCarValidator validationRules = new CreateRentCarValidator();
            ValidationResult result = validationRules.Validate(createRentCarViewModel);

            if (result.IsValid)
            {
                createRentCarViewModel.Status = "Onay Bekliyor";
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createRentCarViewModel);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7244/api/RentCar", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {

                    var dbContext = new Context(); // Veritabanı bağlantısı oluşturulmalı

                    // Detail bölümündeki ilgili öğeyi bul
                    var detailItem = dbContext.Details.FirstOrDefault(x => x.Name == createRentCarViewModel.Car);
                    if (detailItem != null)
                    {
                        detailItem.Total--; // Total değerini azalt
                        dbContext.Update(detailItem); // Güncelleme işlemi
                        await dbContext.SaveChangesAsync(); // Değişiklikleri kaydet
                    }
                    TempData["SuccessMessage"] = "Kiralama İşlemi Başarıyla Tamamlandı. Lütfen Mailinizi Kontrol Ediniz.";
                    return RedirectToAction("Index");
                }
                return View();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                TempData["ErrorMessages"] = result.Errors.Select(e => e.ErrorMessage).ToList();

            }
            return RedirectToAction("Index");



        }
    }
}
