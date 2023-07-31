

using System.ComponentModel.DataAnnotations;

namespace CarBook.UI.Models.Service
{
    public class AddServiceViewModel
    {
        [Required(ErrorMessage ="Bu İçerik Boş Geçilemez")]
        public string? Icon { get; set; }
        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public string? Description { get; set; }
    }
}
