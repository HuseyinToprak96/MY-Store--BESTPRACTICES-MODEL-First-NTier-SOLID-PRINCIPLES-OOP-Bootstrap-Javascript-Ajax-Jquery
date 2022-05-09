using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            var urunler = (from u in _data.Urunler
                           orderby u.Adet
                           where u.Adet>0
                           select u).Take(4);
            return await urunler.ToListAsync();
        }

        public async Task<Urun> EklenenUrunuGoster(Urun urun)
        {
         var u=  await _data.Urunler.AddAsync(urun);
           return u.Entity;
        }

        public async Task<List<Urun>> EncokSatan()
        {
            var urunler = (from u in _data.Urunler
                           orderby u.FaturaDetay.Count
                           descending
                           where u.Adet > 0
                           select u).Take(4);
            return await urunler.ToListAsync();
        }

        public async Task<List<Urun>> FavoriUrunler()
        {
            var urunler = (from u in _data.Urunler
                           orderby u.sepetDetay.Count       
                           descending
                           where u.Adet > 0
                           select u).Take(4);
            return await urunler.ToListAsync();
        }

        public IQueryable<Urun> GetAll()
        {
            return _data.Urunler.AsQueryable().AsNoTracking();
        }
        public async Task<List<Urun>> TumUrunBilgileri()
        {
            return await _data.Urunler.Include(x => x.altKategori).ThenInclude(x => x.kategori).ToListAsync();
        }

        public async Task<Urun> UrunDetay(int id)
        {
            return await _data.Urunler.Include(x => x.kimeGore).Include(x => x.altKategori).ThenInclude(x => x.kategori).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Urun>> Yeni4Urun()
        {
            var urunler = (from u in _data.Urunler
                           orderby u.EklenmeTarihi
                           descending
                           where u.Adet > 0
                           select u).Take(4);
                          
            return await urunler.ToListAsync();
        }
    }
}
