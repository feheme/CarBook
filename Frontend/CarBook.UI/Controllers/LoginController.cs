using CarBook.EntityLayer.Concrete;
using CarBook.UI.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserModel loginUserModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(loginUserModel.Username, loginUserModel.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "AdminRentCar");
            }
            else { 
            ModelState.AddModelError("","Kullanıcı Adı veya Şifre Yanlış");
           
            return View(loginUserModel);

            }



        }
        public async Task<IActionResult> Logout()
        {
            // Oturumu kapat
            await _signInManager.SignOutAsync();

            // İstenilen yönlendirme yapılabilir
            return RedirectToAction("Index", "Login");
        }
    }
}
