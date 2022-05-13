using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class FaturaRepository : Repository<Fatura>, IFaturaRepository
    {
        public FaturaRepository(Data data) : base(data)
        {
        }

        public async Task<Fatura> FaturaDetay(int id)
        {
            return await _data.Faturalar.Include(x => x.faturaDetays).ThenInclude(x=>x.urun).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Fatura>> KisininFaturalari(int UyeId)
        {
            return await _data.Faturalar.Include(x => x.faturaDetays).Where(x => x.UyeId == UyeId).ToListAsync();
        }
    }
}
