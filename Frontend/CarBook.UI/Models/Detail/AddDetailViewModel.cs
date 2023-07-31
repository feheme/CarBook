

using System.ComponentModel.DataAnnotations;

namespace CarBook.UI.Models.Detail
{
    public class AddDetailViewModel
    {
        [Required(ErrorMessage ="Bu İçerik Boş Geçilemez")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public string? Image { get; set; }
   

        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public double DayPrice { get; set; }

        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public double MonthPrice { get; set; }

        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public string? Mileage { get; set; }

        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public string? Transmission { get; set; }

        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public string? Seats { get; set; }

        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public string? Fuel { get; set; }

        [Required(ErrorMessage = "Bu İçerik Boş Geçilemez")]
        public int Total { get; set; }
    }
}
