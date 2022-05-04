using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class UyeRepository : Repository<Uye>, IUyeRepository
    {
        public UyeRepository(Data data) : base(data)
        {
        }

        public Task<Uye> uyeDetay(int UyeId)
        {
            return _data.Uyeler.Include(x => x.Faturalar).ThenInclude(x => x.faturaDetays).ThenInclude(x => x.urun).Include(x => x.cinsiyet).Include(x => x.sepet).ThenInclude(x=>x.SepetDetay).ThenInclude(x=>x.urun).Where(x => x.Id == UyeId).SingleOrDefaultAsync();
        }
        public async Task<Uye> UyeLogin(string mail, string sifre)
        {
            return await _data.Uyeler.Where(x => x.Mail == mail && x.Sifre == sifre).SingleOrDefaultAsync();
        }

        public async Task Yetkilendir(bool yetki, int id)
        {
            var uye = await _data.Uyeler.Where(x => x.Id == id).SingleOrDefaultAsync();
            await _data.SaveChangesAsync();

        }
    }
}
