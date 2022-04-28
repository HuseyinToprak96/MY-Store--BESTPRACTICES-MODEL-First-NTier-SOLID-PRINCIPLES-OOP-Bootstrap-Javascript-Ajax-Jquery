using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
   public interface IAltKategoriService:IService<AltKategori>
    {
        Task<List<AltKategori>> KategoriyeAitAltKategoriler(int id);
    }
}
