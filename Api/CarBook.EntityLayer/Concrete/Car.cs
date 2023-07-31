using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.EntityLayer.Concrete
{
    public class Car
    {
        public int CarID { get; set; }
        public string? CoverImage { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public int Price { get; set; }


    }
}
