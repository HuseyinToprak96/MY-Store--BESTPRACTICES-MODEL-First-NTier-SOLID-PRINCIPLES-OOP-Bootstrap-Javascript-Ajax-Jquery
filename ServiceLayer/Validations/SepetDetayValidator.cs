using CoreLayer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validations
{
    public class SepetDetayValidator: AbstractValidator<SepetDetayDto>
    {
        public SepetDetayValidator()
        {
            RuleFor(x => x.UrunId).InclusiveBetween(1, int.MaxValue).WithMessage("Aralık Dışı!");
        }
    }
}
