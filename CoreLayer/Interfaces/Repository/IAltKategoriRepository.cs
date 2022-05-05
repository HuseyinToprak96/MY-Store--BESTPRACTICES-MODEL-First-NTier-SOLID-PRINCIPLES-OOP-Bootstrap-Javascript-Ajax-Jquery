using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface IAltKategoriRepository : IRepository<AltKategori>
    {
        Task<List<AltKategori>> KategoriyeAitAltKategoriler(int id);
        Task<AltKategori> Eklenen(AltKategori altKategori);
    }
    
}
