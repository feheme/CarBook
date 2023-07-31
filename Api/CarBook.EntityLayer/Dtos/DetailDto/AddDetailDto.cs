using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.EntityLayer.Dtos.DetailDto
{
    public class AddDetailDto
    {
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
