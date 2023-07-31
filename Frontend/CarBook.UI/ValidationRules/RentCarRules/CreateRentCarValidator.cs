using CarBook.UI.Models.RentCar;
using FluentValidation;

namespace CarBook.UI.ValidationRules.RentCarRules
{
    public class CreateRentCarValidator : AbstractValidator<CreateRentCarViewModel>
    {
        public CreateRentCarValidator()
        {

            RuleFor(x => x.PickUpDate)
           .GreaterThanOrEqualTo(DateTime.Today)
           .WithMessage("Geçerli veya ileri bir tarih seçiniz.");

            RuleFor(x => x.DropOffDate)
            .GreaterThan(x => x.PickUpDate)
            .WithMessage("Varış tarihi, Alış tarihinden daha ileri bir tarih olmalıdır.");


            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı gereklidir.");
            RuleFor(x => x.Mail).NotEmpty().EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası alanı gereklidir.");
            RuleFor(x => x.Car).NotEmpty().WithMessage("Araç seçimi yapınız.");
            RuleFor(x => x.PickUpLocation).NotEmpty().WithMessage("Kalkış lokasyonu alanı gereklidir.");
            RuleFor(x => x.DropOffLocation).NotEmpty().WithMessage("Varış lokasyonu alanı gereklidir.");
            RuleFor(x => x.PickUpDate).NotNull().WithMessage("Alış tarihi alanı gereklidir.");
            RuleFor(x => x.DropOffDate).NotNull().WithMessage("Varış tarihi alanı gereklidir.");
        

        }
    }
}
