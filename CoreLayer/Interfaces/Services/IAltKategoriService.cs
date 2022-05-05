using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
    public interface IAltKategoriService : IService<AltKategori>
    {
        Task<List<AltKategori>> KategoriyeAitAltKategoriler(int id);
        Task<AltKategori> Eklenen(AltKategori altKategori);
    }
}
