using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class SepetRepository : Repository<Sepet>, ISepetRepository
    {
        public SepetRepository(Data data) : base(data)
        {
        }

        public async Task<Sepet> MusterininSepeti(int UyeId)
        {
            return await _data.Sepetler.Include(x => x.SepetDetay).ThenInclude(x => x.urun).Where(x => x.UyeId == UyeId).SingleOrDefaultAsync();
        }

        public async Task<List<SepetDetay>> sepetDetaylari(int sepetId)
        {
            return await _data.SepetDetaylar.Include(x => x.urun).Where(x => x.SepetId == sepetId).ToListAsync();
        }

        public async Task SepeteEkle(int UrunId, int UyeId)
        {
            var sepet = await _data.Sepetler.Where(x=>x.UyeId==UyeId).SingleOrDefaultAsync();
            SepetDetay sepetDetay = new SepetDetay();
            sepetDetay.SepetId = sepet.Id;
            sepetDetay.EklenmeTarihi = DateTime.Now;
            sepetDetay.UrunId = UrunId;
            sepetDetay.Adet = 1;
            _data.SepetDetaylar.Add(sepetDetay);
        }

        public void SepettenCikar(int Id)
        {
         _data.SepetDetaylar.Remove(_data.SepetDetaylar.Where(i => i.Id == Id).SingleOrDefault());
         _data.SaveChanges();
        }
    }
}
