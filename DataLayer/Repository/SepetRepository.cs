using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class SepetRepository : Repository<Sepet>,ISepetRepository
    {
        public SepetRepository(Data data) : base(data)
        {
        }

        public async Task<Sepet> MusterininSepeti(int UyeId)
        {
           return await _data.Sepetler.Include(x => x.SepetDetay).Where(x => x.UyeId == UyeId).SingleOrDefaultAsync();
           
        }

        public async Task SepeteEkle(SepetDetay sepetDetay,int UyeId)
        {
         var Sepet=  await _data.Sepetler.Where(x => x.UyeId == UyeId).SingleOrDefaultAsync();
            if (Sepet ==null)
            {
                Sepet sepet = new Sepet();
                sepet.UyeId = UyeId;
                sepet.SepetDetay.Add(sepetDetay);
                await _data.Sepetler.AddAsync(sepet);
                _data.SaveChanges();
            }
            else
            {
              Sepet.SepetDetay.Add(sepetDetay);
                _data.SaveChanges();
            }
        }

        public void SepettenCikar(int SepetDetayId,int UyeId )
        {
          var sepet= _data.Sepetler.Where(sd => sd.UyeId == UyeId).SingleOrDefault();
          var sepetDetay = _data.SepetDetaylar.Where(i => i.Id == SepetDetayId).SingleOrDefault();
          sepet.SepetDetay.Remove(sepetDetay);
          _data.SaveChanges();
        }
    }
}
