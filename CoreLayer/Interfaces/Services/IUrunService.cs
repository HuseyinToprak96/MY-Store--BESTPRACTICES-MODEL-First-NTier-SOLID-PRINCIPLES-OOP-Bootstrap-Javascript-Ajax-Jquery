using CoreLayer.Dtos;
using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
    public interface IUrunService : IService<Urun>
    {
        Task<List<Urun>> EncokSatan();
        Task<List<Urun>> Yeni4Urun();
        Task<List<Urun>> FavoriUrunler();
        Task<List<Urun>> BitmesiYakin();
        Task<List<Urun>> AltKategoriyeGore(int id);
        Task<List<Urun>> TumUrunBilgileri();
        Task<Urun> UrunDetay(int id);
        Task<List<Urun>> OnerilenUrunler(int? cinsId, int? AltKategoriId);
        Task<List<Urun>> Arama(Source source);
        Task<Urun> EklenenUrunuGoster(Urun urun);
        Task<List<StokDto>> StokKontrol(int tehlikeSiniri);
        Task AdetGuncelle(int adet,int id);
    }
}
