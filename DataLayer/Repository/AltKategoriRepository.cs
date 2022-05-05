using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class AltKategoriRepository : Repository<AltKategori>, IAltKategoriRepository
    {
        public AltKategoriRepository(Data data) : base(data)
        {

        }

        public async Task<AltKategori> Eklenen(AltKategori altKategori)
        {
            
            var alt = await _data.AltKategoriler.AddAsync(altKategori);
            return alt.Entity;
        }

        public async Task<List<AltKategori>> KategoriyeAitAltKategoriler(int id)
        {
            return await _data.AltKategoriler.Where(ak => ak.Id == id).ToListAsync();
        }
    }
}
