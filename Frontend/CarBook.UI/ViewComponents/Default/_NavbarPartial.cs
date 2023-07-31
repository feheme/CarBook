using Microsoft.AspNetCore.Mvc;

namespace CarBook.UI.ViewComponents.Default
{
    public class _NavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
