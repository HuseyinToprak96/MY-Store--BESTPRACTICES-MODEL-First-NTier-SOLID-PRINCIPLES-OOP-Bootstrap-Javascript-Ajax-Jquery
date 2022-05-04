using CoreLayer.Entities;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface ISepetRepository : IRepository<Sepet>
    {
        Task SepeteEkle(SepetDetay sepetDetay, int UyeId);
        void SepettenCikar(int Id);
        Task<Sepet> MusterininSepeti(int UyeId);

    }
}
