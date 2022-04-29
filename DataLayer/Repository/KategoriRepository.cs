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
    public class KategoriRepository : Repository<Kategori>,IKategoriRepository
    {
        public KategoriRepository(Data data) : base(data)
        {
        }

        public async Task<List<Kategori>> KategoriyeAitDetaylar()
        {
            return await _data.Kategoriler.Include(x => x.altKategoriler).ThenInclude(x => x.Urunler).ToListAsync();
        }
    }
}
