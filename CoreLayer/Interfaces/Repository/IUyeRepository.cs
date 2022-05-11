using CoreLayer.Entities;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface IUyeRepository : IRepository<Uye>
    {
        Task<Uye> UyeLogin(string mail, string sifre);
        Task Yetkilendir(bool yetki, int id);
        Task<Uye> uyeDetay(int UyeId);
        Task<string> MailBul(int id);
        Task<bool> MailKontrol(string mail);
    }
}
