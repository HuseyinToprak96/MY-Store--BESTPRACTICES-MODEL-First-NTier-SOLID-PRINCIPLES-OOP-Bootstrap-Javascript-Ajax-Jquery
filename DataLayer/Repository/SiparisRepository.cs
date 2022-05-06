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
    public class SiparisRepository : Repository<Siparis>, ISiparisRepository
    {
        public SiparisRepository(Data data) : base(data)
        {
        }

        public async Task DurumGuncelle(int islem)
        {
            var siparisler=await _data.Siparisler.Where(x => x.SiparisDurumu == (Durum)islem).ToListAsync();
            foreach (var siparis in siparisler)
            siparis.SiparisDurumu += 1;
        }

        public async Task SiparisGuncelle(int durum,int id)
        {
            var siparis =await _data.Siparisler.Where(x => x.Id == id).SingleOrDefaultAsync();
            siparis.SiparisDurumu =(Durum)durum;
            
        }

        public async Task<List<Siparis>> Siparisler(Durum durum)
        {
            return await _data.Siparisler.Include(x=>x.uye).Include(x=>x.siparisDetay).ThenInclude(x=>x.urun).Where(x =>(int)x.SiparisDurumu == (int)durum).ToListAsync();
        }
    }
}
