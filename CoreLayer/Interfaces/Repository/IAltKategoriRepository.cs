using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
   public interface IAltKategoriRepository : IRepository<AltKategori>
    {
        Task<List<AltKategori>> KategoriyeAitAltKategoriler(int id);
    }
}
