using CoreLayer.Dtos;
using FluentValidation;

namespace ServiceLayer.Validations
{
    public class KategoriDtoValidator : AbstractValidator<KategoriDto>
    {
        public KategoriDtoValidator()
        {
            RuleFor(x => x.KategoriAdi).NotNull().WithMessage("Null değer alamaz!").NotEmpty().WithMessage("Boş Geçilemez");

        }
    }
}
