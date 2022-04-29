using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
   public interface ISepetRepository:IRepository<Sepet>
    {
        Task SepeteEkle(SepetDetay sepetDetay,int UyeId);
        void SepettenCikar(int SepetDetayId, int UyeId);
        Task<Sepet> MusterininSepeti(int UyeId);

    }
}
