using CoreLayer.Dtos;
using CoreLayer.Entities;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
    public interface IUyeService : IService<Uye>
    {
        Task<GirenBilgileri> UyeLogin(string mail, string sifre);
        Task Yetkilendir(bool yetki, int id);
        Task<Uye> uyeDetay(int UyeId);
        Task<string> MailBul(int id);
    }
}
