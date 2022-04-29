using CoreLayer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
