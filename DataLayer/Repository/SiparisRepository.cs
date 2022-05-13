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

        public async Task<int> SiparisBul(int UyeId)
        {
            var siparis = await _data.Siparisler.Where(x => x.UyeId == UyeId && x.siparisDetay.Count<1).SingleOrDefaultAsync();
            return siparis.Id;
        }

        public async Task<Siparis> SiparisDetay(int id)
        {
            return await _data.Siparisler.Include(x=>x.siparisDetay).ThenInclude(x=>x.urun).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task SiparisGuncelle(int durum,int id)
        {
            var siparis =await _data.Siparisler.Where(x => x.Id == id).SingleOrDefaultAsync();
            siparis.SiparisDurumu =(Durum)durum;
            
        }

        public async Task<List<Siparis>> Siparisler(Durum durum)
        {
            return await _data.Siparisler.Include(x=>x.uye).Include(x=>x.siparisDetay).ThenInclude(x=>x.urun).Where(x =>(int)x.SiparisDurumu == (int)durum).OrderByDescending(x=>x.SiparisTarihi).ToListAsync();
        }

        public void SiparisleriEkle(List<SiparisDetay> siparisDetaylar)
        {
             _data.SiparisDetaylar.AddRange(siparisDetaylar);
           
        }
        public void Puanla(int puan,int id)
        {
          var siparis=  _data.Siparisler.Where(x => x.Id == id).SingleOrDefault();
            siparis.Puan = puan;
        }

        public async Task<double> PuanOrt()
        {
            var ort = await _data.Siparisler.Where(x=>x.Puan!=0).AverageAsync(x => x.Puan);
            return ort;
        }
    }
}
