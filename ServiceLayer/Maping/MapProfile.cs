using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;

namespace ServiceLayer.Maping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Uye, GirenBilgileri>().ReverseMap();
            CreateMap<SepetDetay, SepetDetayDto>().ReverseMap();
            CreateMap<Urun, UrunDto>().ReverseMap();
            CreateMap<Urun, VitrinDto>();
            CreateMap<UrunGuncelleDto, Urun>();
            CreateMap<AltKategori, AltKategoriDto>().ReverseMap();
            CreateMap<Kategori, KategoriDto>().ReverseMap();
            CreateMap<Kategori, KategoriUpdateDto>().ReverseMap();
            CreateMap<Uye, UyeDto>();
            CreateMap<UyeOlDto, Uye>();
            CreateMap<Siparis, SiparisDto>().ReverseMap();
            CreateMap<SiparisDetay, SiparisDetailDto>();
            CreateMap<SiparisDetay, Siparis_Detay_Urun>();
            CreateMap<Siparis, Siparis_Siparis_Detay_UrunDto>().ForMember(x => x.siparisDetaylar, opt => opt.MapFrom(x => x.siparisDetay));//auto mapper Navigation Property
        }
    }
}
