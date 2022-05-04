using CoreLayer.Dtos;
using FluentValidation;

namespace ServiceLayer.Validations
{
    public class SepetDetayValidator : AbstractValidator<SepetDetayDto>
    {
        public SepetDetayValidator()
        {
            RuleFor(x => x.UrunId).InclusiveBetween(1, int.MaxValue).WithMessage("Aralık Dışı!");
        }
    }
}
