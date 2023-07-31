using Microsoft.AspNetCore.Mvc;

namespace CarBook.UI.ViewComponents.Default
{
    public class _HeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
