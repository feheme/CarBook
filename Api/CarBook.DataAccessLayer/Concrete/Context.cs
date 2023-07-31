using CarBook.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =FEHEME\\SQLEXPRESS;" +
                "initial catalog = MyThesisProject;" +
                "integrated security = true; " +
                "TrustServerCertificate = True");
        }

        public DbSet<Car>? Cars { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Detail>? Details { get; set; }
        public DbSet<RentCar>? RentCars { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Testimonial>? Testimonials { get; set; }


    }
}
