using CoreLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface IUrunRepository : IRepository<Urun>
    {
        Task<List<Urun>> EncokSatan();
        Task<List<Urun>> Yeni4Urun();
        Task<List<Urun>> FavoriUrunler();
        Task<List<Urun>> BitmesiYakin();
        Task<List<Urun>> AltKategoriyeGore(int id);
        Task<List<Urun>> TumUrunBilgileri();
        IQueryable<Urun> GetAll();
        Task<Urun> UrunDetay(int id);
    }
}
