using CoreLayer.Dtos;
using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
    public interface ISiparisService:IService<Siparis>
    {
        Task<List<Siparis>> Siparisler(Durum durum);
        Task DurumGuncelle(int durum);
        Task SiparisGuncelle(int durum, int id);
        Task<Siparis_Siparis_Detay_UrunDto> SiparisDetay(int id);
    }
}
