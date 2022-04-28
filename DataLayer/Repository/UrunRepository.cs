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
    public class UrunRepository : Repository<Urun>, IUrunRepository
    {
        public UrunRepository(Data data) : base(data)
        {
        }

        public async Task<List<Urun>> AltKategoriyeGore(int id)
        {
            return await _data.Urunler.Where(x => x.AltKategoriId == id).ToListAsync();
        }

        public Task<List<Urun>> EncokSatan()
        {
            throw new NotImplementedException();
        }

        public Task<List<Urun>> Yeni4Urun()
        {
            throw new NotImplementedException();
        }
    }
}
