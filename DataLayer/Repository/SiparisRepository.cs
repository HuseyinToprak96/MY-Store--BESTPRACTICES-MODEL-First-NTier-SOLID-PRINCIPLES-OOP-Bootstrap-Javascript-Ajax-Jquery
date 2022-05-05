using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class SiparisRepository : Repository<Siparis>, ISiparisRepository
    {
        public SiparisRepository(Data data) : base(data)
        {
        }

        public async Task<List<Siparis>> Siparisler(Durum durum)
        {
            return await _data.Siparisler.Include(x=>x.uye).Include(x=>x.siparisDetay).ThenInclude(x=>x.urun).Where(x => x.SiparisDurumu == durum).ToListAsync();
        }
    }
}
