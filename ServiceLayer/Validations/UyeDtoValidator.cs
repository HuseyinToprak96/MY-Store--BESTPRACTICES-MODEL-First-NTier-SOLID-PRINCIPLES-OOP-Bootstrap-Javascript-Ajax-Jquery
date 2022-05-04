using CoreLayer.Dtos;
using FluentValidation;

namespace ServiceLayer.Validations
{
    public class UyeDtoValidator : AbstractValidator<UyeOlDto>
    {
        public UyeDtoValidator()
        {
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Mail Adresi doğru formatta girilmedi.");
            RuleFor(x => x.Telefon).NotEmpty().WithMessage("Telefon numarası alanı zorunludur.");
            RuleFor(x => x.Sifre).NotNull().NotEmpty().WithMessage("Şifresiz nasıl giriş yapcaksın!!");
        }
    }
}
