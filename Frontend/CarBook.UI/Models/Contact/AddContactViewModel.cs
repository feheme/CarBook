

using System.ComponentModel.DataAnnotations;

namespace CarBook.UI.Models.Contact
{
    public class AddContactViewModel
    {
        [Required(ErrorMessage ="Bu İçerik Boş Geçilemez")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public string? Mail { get; set; }

        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public string? Message { get; set; }

        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public DateTime Date { get; set; }
    }
}
