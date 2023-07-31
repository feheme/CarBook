using CarBook.EntityLayer.Concrete;
using CarBook.EntityLayer.Dtos.CarDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.BusinessLayer.ValidationRules.CarDtoValidator
{
    public class AddCarDtoValidator : AbstractValidator<AddCarDto>
    {
        public AddCarDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İçerik Boş Geçilemez.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("İçerik Boş Geçilemez.");
            RuleFor(x => x.Brand).NotEmpty().WithMessage("İçerik Boş Geçilemez.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("İçerik Boş Geçilemez.");
            RuleFor(x => x.CoverImage).NotEmpty().WithMessage("İçerik Boş Geçilemez.");
        }
    }
}
