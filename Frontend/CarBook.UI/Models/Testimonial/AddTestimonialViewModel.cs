

using System.ComponentModel.DataAnnotations;

namespace CarBook.UI.Models.Testimonial
{
    public class AddTestimonialViewModel
    {
        [Required(ErrorMessage ="Bu İçerik Boş Geçilemez")]
        public string? Image { get; set; }
        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]

        public string? Description { get; set; }
        [Required(ErrorMessage ="Bu İçerik Boş Geçilemez")]

        public string? Name { get; set; }
    }
}
