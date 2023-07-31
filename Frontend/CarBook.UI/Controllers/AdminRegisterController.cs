using CarBook.EntityLayer.Concrete;
using CarBook.UI.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.UI.Controllers
{
    public class AdminRegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminRegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserModel createNewUserModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = createNewUserModel.Name,
                Email = createNewUserModel.Mail,
                Surname = createNewUserModel.Surname,
                UserName = createNewUserModel.Username,               

            };
            var result = await _userManager.CreateAsync(appUser, createNewUserModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "AdminRentCar");
            }
            return View();
        }
    }
}
