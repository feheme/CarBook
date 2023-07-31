using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.EntityLayer.Dtos.TestimonialDto
{
    public class UpdateTestimonialDto
    {
        public int TestimonialID { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
    }
}
