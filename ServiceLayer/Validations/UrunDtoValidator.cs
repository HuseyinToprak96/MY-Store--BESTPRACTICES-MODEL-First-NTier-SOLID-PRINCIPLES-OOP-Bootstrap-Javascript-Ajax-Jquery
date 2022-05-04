using CoreLayer.Dtos;
using FluentValidation;
namespace ServiceLayer.Validations
{
    public class UrunDtoValidator : AbstractValidator<UrunDto>
    {
        public UrunDtoValidator()
        {
            RuleFor(x => x.UrunAdi).NotNull().WithMessage("Bu alan Gereklidir.").NotEmpty().WithMessage("Boş geçilemez...");
            RuleFor(x => x.Ucret).InclusiveBetween(1, 10000).WithMessage("1 ile 10000 TL arası fiyat giriniz.");
            RuleFor(x => x.Adet).InclusiveBetween(1, 1000).WithMessage("1 seferde en fazla 1000 ürün eklenebilir");
            RuleFor(x => x.Resim).NotNull().WithMessage("Resim alanı zorunludur.").NotEmpty().WithMessage("Resim alanı zorunludur.");
            RuleFor(x => x.CinsiyetId).InclusiveBetween(1, int.MaxValue).WithMessage("Aralık dışı!");
            RuleFor(x => x.AltKategoriId).InclusiveBetween(1, int.MaxValue).WithMessage("Aralık dışı");

        }
    }
}
