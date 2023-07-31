using System.ComponentModel.DataAnnotations;

namespace CarBook.UI.Models.Identity
{
    public class LoginUserModel
    {
        [Required(ErrorMessage = "Kullanıcı Adını Giriniz.")]
        
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifrenizi Giriniz.")]
        public string Password { get; set; }
    }
}
