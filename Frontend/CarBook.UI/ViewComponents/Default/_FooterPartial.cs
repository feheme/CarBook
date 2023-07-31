using Microsoft.AspNetCore.Mvc;

namespace CarBook.UI.ViewComponents.Default
{
    public class _FooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
