using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface ISepetRepository : IRepository<Sepet>
    {
        Task SepeteEkle(int UrunId, int UyeId);
        void SepettenCikar(int Id);
        Task<Sepet> MusterininSepeti(int UyeId);
        Task<List<SepetDetay>> sepetDetaylari(int sepetId);
        Task SepetiTemizle(int id);
        Task<int> SepetIdBul(int UyeId);

    }
}
