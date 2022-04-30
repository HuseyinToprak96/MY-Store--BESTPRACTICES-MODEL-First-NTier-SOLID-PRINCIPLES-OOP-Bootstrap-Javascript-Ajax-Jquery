using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
   public interface IUrunService:IService<Urun>
    {
        Task<Urun[]> EncokSatan();
        Task<Urun[]> Yeni4Urun();
        Task<Urun[]> FavoriUrunler();
        Task<Urun[]> BitmesiYakin();
        Task<List<Urun>> AltKategoriyeGore(int id);
        Task<List<Urun>> TumUrunBilgileri();
    }
}
