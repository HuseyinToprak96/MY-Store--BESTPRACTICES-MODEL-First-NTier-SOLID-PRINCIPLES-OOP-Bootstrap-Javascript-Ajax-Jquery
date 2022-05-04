using CoreLayer.Dtos;
using FluentValidation;

namespace ServiceLayer.Validations
{
    public class AltKategoriValidator : AbstractValidator<AltKategoriDto>
    {
        public AltKategoriValidator()
        {
            RuleFor(x => x.AltKategoriAdi).NotNull().WithMessage("Boş Geçilemez.").NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.KategoriId).InclusiveBetween(1, int.MaxValue).WithMessage("Aralık dışı!");
        }
    }
}
