using CoreLayer.Dtos;
using CoreLayer.Entities;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
    public interface ISepetService : IService<Sepet>
    {
        Task SepeteEkle(SepetDetayDto sepetDetay, int UyeId);
        void SepettenCikar(int Id);
        Task<Sepet> MusterininSepeti(int UyeId);
    }
}
