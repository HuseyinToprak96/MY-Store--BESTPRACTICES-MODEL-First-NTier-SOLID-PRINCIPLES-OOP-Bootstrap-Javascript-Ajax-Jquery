using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface IKategoriRepository : IRepository<Kategori>
    {
        Task<List<Kategori>> KategoriyeAitDetaylar();
    }
}
