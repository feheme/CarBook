using CarBook.BusinessLayer.Abstract;
using CarBook.BusinessLayer.Concrete;
using CarBook.DataAccessLayer.Abstract;
using CarBook.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.BusinessLayer.Container
{
    public static class Extension
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICarDal, EfCarDal>();
            services.AddScoped<ICarService, CarManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IDetailDal, EfDetailDal>();
            services.AddScoped<IDetailService, DetailManager>();

            services.AddScoped<IRentCarDal, EfRentCarDal>();
            services.AddScoped<IRentCarService, RentCarManager>();

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

        }
    }
}
