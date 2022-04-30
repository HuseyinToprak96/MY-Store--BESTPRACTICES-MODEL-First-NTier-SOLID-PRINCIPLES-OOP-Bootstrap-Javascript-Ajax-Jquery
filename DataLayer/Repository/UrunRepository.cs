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
    public class UrunRepository : Repository<Urun>, IUrunRepository
    {
        public UrunRepository(Data data) : base(data)
        {
        }

        public async Task<List<Urun>> AltKategoriyeGore(int id)
        {
            return await _data.Urunler.Where(x => x.AltKategoriId == id).ToListAsync();
        }

        public async Task<List<Urun>> BitmesiYakin()
        {
            var Urunler = await _data.Urunler.OrderByDescending(x => x.Adet).Where(x=>x.Adet>0).ToListAsync();
            List<Urun> urunler = new List<Urun>();
            for (int i = 0; i <4; i++)
            urunler.Add(Urunler[i]);
            return urunler;
        }

        public async Task<List<Urun>> EncokSatan()
        {
            var Urunler =await _data.Urunler.Include(x=>x.altKategori).ThenInclude(x=>x.kategori).OrderBy(x=>x.FaturaDetay.Count).ToListAsync();
            List<Urun> urunler = new List<Urun>();
            for (int i = 0; i < 4; i++)
                urunler.Add(Urunler[i]);
            return urunler;
        }

        public async Task<List<Urun>> FavoriUrunler()
        {
            var Urunler =await _data.Urunler.Include(x => x.altKategori).ThenInclude(x => x.kategori).OrderBy(x => x.sepetDetay.Count).ToListAsync();
            List<Urun> urunler = new List<Urun>();
            for (int i = 0; i < 4; i++)
                urunler.Add(Urunler[i]);
            return urunler;
        }

        public IQueryable<Urun> GetAll()
        {
            return _data.Urunler.AsQueryable().AsNoTracking();
        }
        public async Task<List<Urun>> TumUrunBilgileri()
        {
           return await _data.Urunler.Include(x => x.altKategori).ThenInclude(x=>x.kategori).ToListAsync();
        }

        public async Task<List<Urun>> Yeni4Urun()
        {
            var Urunler = await _data.Urunler.OrderBy(x => x.EklenmeTarihi).ToListAsync();
            List<Urun> urunler = new List<Urun> ();
            for (int i = 0; i < 4; i++)
                urunler.Add(Urunler[i]);
            return urunler;
        }
    }
}
