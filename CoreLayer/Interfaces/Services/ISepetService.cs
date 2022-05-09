using CoreLayer.Dtos;
using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
    public interface ISepetService : IService<Sepet>
    {
        Task SepeteEkle(int UrunId, int UyeId);
        Task SepettenCikar(int SepetDetayId);
        Task<Sepet> MusterininSepeti(int UyeId);
        Task<List<SepetDetay>> sepetDetaylari(int sepetId);
        Task SepetiTemizle(int id);
        Task<int> SepetIdBul(int UyeId);
    }
}
