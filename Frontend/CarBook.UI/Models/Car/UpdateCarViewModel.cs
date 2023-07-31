using System.ComponentModel.DataAnnotations;

namespace CarBook.UI.Models.Car
{
    public class UpdateCarViewModel
    {
        public int CarID { get; set; }
        [Required(ErrorMessage = "Araba Resmi Boş Geçilemez")]
        public string? CoverImage { get; set; }
        [Required(ErrorMessage = "Araba İsmi Boş Geçilemez")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Araba Markası Boş Geçilemez")]
        public string? Brand { get; set; }
        [Required(ErrorMessage = "Araba Kiralama Fiyatı Boş Geçilemez")]
        public int Price { get; set; }
    }
}
