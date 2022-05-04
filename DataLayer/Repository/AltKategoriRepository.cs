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
        public async Task<List<AltKategori>> KategoriyeAitAltKategoriler(int id)
        {
            return await _data.AltKategoriler.Where(ak => ak.Id == id).ToListAsync();
        }
    }
}
