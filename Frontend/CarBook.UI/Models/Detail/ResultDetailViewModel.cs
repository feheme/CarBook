using System.ComponentModel.DataAnnotations;

namespace CarBook.UI.Models.Detail
{
    public class ResultDetailViewModel
    {
        public int DetailID { get; set; }

        
        public string? Name { get; set; }

        public string? Image { get; set; }

        public double DayPrice { get; set; }
        public double MonthPrice { get; set; }


        public string? Mileage { get; set; }

        
        public string? Transmission { get; set; }

        public string? Seats { get; set; }

     
        public string? Fuel { get; set; }

     
        public int Total { get; set; }
    }
}
