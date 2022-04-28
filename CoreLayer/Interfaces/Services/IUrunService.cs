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
        Task<List<Urun>> EncokSatan();
        Task<List<Urun>> Yeni4Urun();
        Task<List<Urun>> AltKategoriyeGore(int id);
    }
}
