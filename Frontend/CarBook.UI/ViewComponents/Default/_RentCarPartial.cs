using Microsoft.AspNetCore.Mvc;

namespace CarBook.UI.ViewComponents.Default
{
    public class _RentCarPartial : ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
