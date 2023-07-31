using AutoMapper;
using CarBook.EntityLayer.Concrete;
using CarBook.EntityLayer.Dtos.CarDto;
using CarBook.EntityLayer.Dtos.ContactDto;
using CarBook.EntityLayer.Dtos.DetailDto;
using CarBook.EntityLayer.Dtos.RentCarDto;

using CarBook.EntityLayer.Dtos.TestimonialDto;
using CarBook.EntityLayer.Dtos.ServiceDto;


namespace CarBook.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Car, AddCarDto>().ReverseMap();
            CreateMap<Car, UpdateCarDto>().ReverseMap();

            CreateMap<Contact, AddContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();

            CreateMap<Detail, AddDetailDto>().ReverseMap();
            CreateMap<Detail, UpdateDetailDto>().ReverseMap();

            CreateMap<RentCar, AddRentCarDto>().ReverseMap();
            CreateMap<RentCar, UpdateRentCarDto>().ReverseMap();

            CreateMap<Service, AddServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();

            CreateMap<Testimonial, AddTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();




        }
    }
}
