using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Maping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Uye, GirenBilgileri>().ReverseMap();
            CreateMap<SepetDetay, SepetDetayDto>().ReverseMap();
            CreateMap<Urun, UrunDto>().ReverseMap();
            CreateMap<Urun, VitrinDto>();
            CreateMap<AltKategori, AltKategoriDto>().ReverseMap();
            CreateMap<Kategori, KategoriDto>().ReverseMap();
        }
    }
}
