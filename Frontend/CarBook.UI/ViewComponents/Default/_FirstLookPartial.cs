using Microsoft.AspNetCore.Mvc;

namespace CarBook.UI.ViewComponents.Default
{
    public class _FirstLookPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

