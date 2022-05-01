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
           return await _data.Sepetler.Include(x => x.SepetDetay).ThenInclude(x=>x.urun).Where(x => x.UyeId == UyeId).SingleOrDefaultAsync();
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

        public void SepettenCikar(int Id)
        {
          var sepetDetay =_data.SepetDetaylar.Remove(_data.SepetDetaylar.Where(i => i.Id == Id).SingleOrDefault());
          _data.SaveChanges();
        }
    }
}
