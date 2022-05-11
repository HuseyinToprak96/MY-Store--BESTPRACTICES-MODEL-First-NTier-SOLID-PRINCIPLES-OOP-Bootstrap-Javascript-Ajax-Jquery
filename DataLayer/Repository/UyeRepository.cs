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

        public async Task<string> MailBul(int id)
        {
            //View kullanımına örnek olabilir...Anonim object
          var mail= await _data.Uyeler.Select(x=>new {x.Id,x.Mail }).Where(x => x.Id == id).Select(x=>x.Mail).SingleOrDefaultAsync();
            return mail;
        }
        public async Task<bool> MailKontrol(string mail)
        {
         bool kontrol=true;
         var uye=  await _data.Uyeler.Where(x => x.Mail == mail).SingleOrDefaultAsync();
            if (uye==null)
            kontrol = false;
            return kontrol;
        }
        public Task<Uye> uyeDetay(int UyeId)
        {
            return _data.Uyeler.Include(x => x.Faturalar).ThenInclude(x => x.faturaDetays).ThenInclude(x => x.urun).Include(x=>x.sepet).ThenInclude(x=>x.SepetDetay).ThenInclude(x=>x.urun).Include(x=>x.Siparisler).ThenInclude(x=>x.siparisDetay).ThenInclude(x=>x.urun).Where(x => x.Id == UyeId).SingleOrDefaultAsync();
        }
        public async Task<Uye> UyeLogin(string mail, string sifre)
        {
            return await _data.Uyeler.Where(x => x.Mail == mail && x.Sifre == sifre).SingleOrDefaultAsync();
        }

        public async Task Yetkilendir(bool yetki, int id)
        {
            var uye = await _data.Uyeler.Where(x => x.Id == id).SingleOrDefaultAsync();
            uye.Yetki = yetki;
            await _data.SaveChangesAsync();

        }
    }
}
